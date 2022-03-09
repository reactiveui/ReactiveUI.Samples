using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using WinForms.Reactive.Client.Helpers;
using WinForms.Reactive.Client.Interactions;
using WinForms.Reactive.Client.Services;

namespace WinForms.Reactive.Client.ViewModels;

/*
 * Here we are using Fody syntax `[Reactive]` & `[ObservableAsProperty]` to avoid boilerplate code.
 * Ref: https://www.reactiveui.net/docs/handbook/view-models/boilerplate-code
 *
 * PS. Fody implements this pattern, but it hides `ThrownException`.
 *
 * Fody:
 * [Reactive] public object SelectedItem { get; set; } = null;
 *
 * Explicit way:
 * private object _selectedItem;
 * public object SelectedItem
 * {
 * 	get => _selectedItem;
 * 	set => this.RaiseAndSetIfChanged(ref _selectedItem, value);
 * }
 *
 * Fody:
 * [ObservableAsProperty] public IEnumerable<ItemDto> SearchResults { get; }
 * [ObservableAsProperty] public string FirstName { get; }
 *
 * Explicit way:
 * private readonly ObservableAsPropertyHelper<IEnumerable<ItemDto>> _searchResults;
 * public IEnumerable<ItemDto> SearchResults => _searchResults.Value;
 *
 * readonly ObservableAsPropertyHelper<string> _firstName;
 * public string FirstName => _firstName.Value;
 */

public class ItemsViewModel : ReactiveObject, IRoutableViewModel
{
	private IItemsService _itemsService;

	public string UrlPathSegment => nameof(ItemsViewModel);
	public IScreen HostScreen { get; protected set; } = null!;

	// Commands
	public ReactiveCommand<Unit, IEnumerable<ItemDto>> LoadItemsCommand { get; }
	public ReactiveCommand<Unit, Unit> ShowDetailsCommand { get; }

	// Input
	[Reactive] public string SearchStartsWith { get; set; } = string.Empty;
	[Reactive] public string SearchEndsWith { get; set; } = string.Empty;
	[Reactive] public (Guid? tagId, int index) SelectedItem { get; set; }

	// Output - OAPH must be initialized via `initialValue` parameter in .ToPropertyEx(...)
	[ObservableAsProperty] public IEnumerable<ItemDto> Items { get; }
	[ObservableAsProperty] public IEnumerable<ItemDto> ItemsFiltered { get; } 
	[ObservableAsProperty] public IEnumerable<ItemTagDto> SelectedItemTags { get; } 
	[ObservableAsProperty] public bool IsLoading { get; } 
	[ObservableAsProperty] public bool HasItems { get; } 
	[ObservableAsProperty] public bool HasItemSelection { get; } 
	[ObservableAsProperty] public bool HasSubItems { get; } 

	public ItemsViewModel(
		IScheduler mainThreadScheduler = null,
		IItemsService? itemsService = null
		)
	{
		mainThreadScheduler = mainThreadScheduler ?? RxApp.MainThreadScheduler;
		_itemsService = itemsService ?? Locator.Current.GetService<IItemsService>()!;

		/*
		 * `LoadItemsCommand` is a command that returns a list from an async call (from an asyc backend, for example).
		 *
		 * We guard agains multiple execution via the `canExecute` condition.
		 * We set a flag `IsExecuting` to show a progressbar/spinner.
		 * We can handle exceptions if needed.
		 * We refresh automatically the list every 5 minutes.
		 */
		LoadItemsCommand = ReactiveCommand.CreateFromTask(LoadItems, LoadItemsCommand?.IsExecuting.Select(x => !x), mainThreadScheduler);
		LoadItemsCommand.IsExecuting.ToPropertyEx(this, x => x.IsLoading, initialValue: false);
		//LoadItemsCommand.ThrownExceptions.Subscribe(error => { /* Handle errors here */ });
		LoadItemsCommand
			.ObserveOn(mainThreadScheduler)
			.ToPropertyEx(this, x => x.Items, initialValue: Enumerable.Empty<ItemDto>());

		var interval = TimeSpan.FromMinutes(5);
		Observable.Timer(interval, interval, mainThreadScheduler)
			.Select(time => Unit.Default)
			.ObserveOn(mainThreadScheduler)
			.InvokeCommand(this, x => x.LoadItemsCommand);

		ShowDetailsCommand = ReactiveCommand.CreateFromTask(ShowDetails, this.WhenAnyValue(x => x.HasItemSelection), mainThreadScheduler);

		/*
		 * `WhenAny` is he same as `Observable.CombineLatest`.
		 * Hence this is equal to
		 *
		 * Observable.CombineLatest(
		 *	this.WhenAnyValue(x => x.Items),
		 *	this.WhenAnyValue(x => x.SearchStartsWith),
		 *		this.WhenAnyValue(x => x.SearchEndsWith),
		 *	(items, startsWith, endsWith) => (items, startsWith, endsWith))
		 * .Select(...)
		 * .etc
		 */
		this.WhenAny(x => x.Items, x => x.SearchStartsWith, x => x.SearchEndsWith, (items, startsWith, endsWith) => (items, startsWith, endsWith))
			.Throttle(TimeSpan.FromMilliseconds(800), mainThreadScheduler)
			.DistinctUntilChanged()
			.Select(x =>
			{
				// uncomment to check how Catch() works
				//throw new Exception("ahah");

				var r = (x.items.Value ?? Enumerable.Empty<ItemDto>())
					.Where(i =>
						(string.IsNullOrEmpty(x.startsWith.Value) || i.Name.StartsWith(x.startsWith.Value))
						&&
						(string.IsNullOrEmpty(x.endsWith.Value) || i.Name.EndsWith(x.endsWith.Value)
						))
					.ToList();
				return r;
			})
			.Catch(Observable.Return(Enumerable.Empty<ItemDto>()))
			.ObserveOn(mainThreadScheduler)
			.ToPropertyEx(this, x => x.ItemsFiltered, initialValue: Enumerable.Empty<ItemDto>());

		this
			.WhenAnyValue(x => x.Items)
			.Select(items => items != null && items.Any())
			.ToPropertyEx(this, x => x.HasItems, initialValue: false, scheduler: mainThreadScheduler);

		this
			.WhenAnyValue(x => x.SelectedItem)
			.Select(x => x.tagId != null)
			.ToPropertyEx(this, x => x.HasItemSelection, initialValue: false, scheduler: mainThreadScheduler);

		this
			.WhenAny(x => x.SelectedItem, x => x.Items, (selectedItem, items) => (selectedItem, items))
			.Select(x => (Items?.FirstOrDefault(item => item.ItemId == x.selectedItem.Value.tagId)?.Tags?.Count() ?? 0) > 0)
			.ToPropertyEx(this, x => x.HasSubItems, initialValue: false, scheduler: mainThreadScheduler);

		this.WhenAnyValue(x => x.SelectedItem)
			.Throttle(TimeSpan.FromMilliseconds(800), mainThreadScheduler)
			.Where(x => x.tagId != null)
			.Select(x => x.tagId!.Value)
			.SelectMany(FetchDetailAsync)
			.ObserveOn(mainThreadScheduler)
			.ToPropertyEx(this, x => x.SelectedItemTags, initialValue: Enumerable.Empty<ItemTagDto>());
	}

	private async Task<Unit> ShowDetails(CancellationToken token)
	{
		var itemId = this.SelectedItem.tagId;

		var confirm = await MessageInteractions.AskConfirmation.Handle("Are you sure?");
		if (confirm)
		{
			// TODO: is this the right way to spin a new indipendent form?
			var tags = this.Items.First(x => x.ItemId == itemId).Tags;
			var vm = new ItemTagsViewModel(tags);
			var v = vm.GetView();
			v.Show();

			await Task.Delay(2000);
			await MessageInteractions.ShowMessage.Handle("Details were shown");
		}

		return await Task.FromResult(Unit.Default);
	}

	private async Task<IEnumerable<ItemDto>> LoadItems()
	{
		var items = await _itemsService.GetAll();
		return items;
	}

	private async Task<IEnumerable<ItemTagDto>> FetchDetailAsync(Guid id, CancellationToken token)
	{
		var tags = this.Items.Where(x => x.ItemId == id).SelectMany(x => x.Tags).ToList();
		return await Task.FromResult(tags);
	}

}

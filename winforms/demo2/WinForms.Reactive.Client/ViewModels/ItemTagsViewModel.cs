using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using WinForms.Reactive.Client.Interactions;
using WinForms.Reactive.Client.Services;

namespace WinForms.Reactive.Client.ViewModels;

public class ItemTagsViewModel : ReactiveObject
{
	// Commands
	public ReactiveCommand<Unit, Unit> ShowTag { get; }

	// Output
	[ObservableAsProperty] public IEnumerable<ItemTagDto>? Tags { get; } = new List<ItemTagDto>();
	[ObservableAsProperty] public int NumTags { get; } = 0;
	[ObservableAsProperty] public string TagIds { get; } = string.Empty;

	public ItemTagsViewModel(IEnumerable<ItemTagDto> tags)
	{
		// TODO: is this the right way to initiate a OAPH from a constructor?

		var initialTags = Observable.Return(tags);
		initialTags.ToPropertyEx(this, x => x.Tags);

		ShowTag = ReactiveCommand.CreateFromTask(async () =>
		{
			_ = await MessageInteractions.ShowMessage.Handle($"Num tags: {NumTags} - Ids: {TagIds}");
		});

		this
			.WhenAnyValue(x => x.Tags)
			.Select(items => items?.Count() ?? 0)
			.ToPropertyEx(this, x => x.NumTags);

		this
			.WhenAnyValue(x => x.Tags)
			.Select(items => items == null ? string.Empty : string.Join(", ", items.Select(x => x.ItemTagId.ToString("N")).ToList()))
			.ToPropertyEx(this, x => x.TagIds);
	}

}

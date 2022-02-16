using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;
using WinForms.Reactive.Client.Services;
using WinForms.Reactive.Client.ViewModels;

namespace WinForms.Reactive.Client.Views;

public partial class ItemsView : UserControl, IViewFor<ItemsViewModel>
{
	public ItemsViewModel ViewModel { get; set; }
	object IViewFor.ViewModel
	{
		get => ViewModel;
		set => ViewModel = (ItemsViewModel)value;
	}

	public ItemsView()
	{
		InitializeComponent();
		lstItems.DisplayMember = nameof(ItemDto.Name);
		lstItems.ValueMember = nameof(ItemDto.ItemId);

		lstDetails.DisplayMember = nameof(ItemTagDto.Name);
		lstDetails.ValueMember = nameof(ItemTagDto.ItemTagId);

		ViewModel = new ItemsViewModel();

		this.WhenActivated(disposableRegistration =>
		{
			// this will start the command used to load the items as the view is ready
			this.WhenAnyValue(view => view.ViewModel.LoadItemsCommand)
				.Select(cmd => Unit.Default)
				.InvokeCommand(this.ViewModel.LoadItemsCommand)
				.DisposeWith(disposableRegistration);

			//btnLoad.Events().Click.Select(x => Unit.Default)
			//	.InvokeCommand(this, x => x.ViewModel.LoadItemsCommand)
			//	.DisposeWith(disposableRegistration);

			this.BindCommand(ViewModel,
					vm => vm.LoadItemsCommand,
					v => v.btnLoad)
				.DisposeWith(disposableRegistration);

			this.BindCommand(ViewModel,
					vm => vm.ShowDetailsCommand,
					v => v.btnShowDetail)
				.DisposeWith(disposableRegistration);

			this.OneWayBind(ViewModel,
					viewModel => viewModel.IsLoading,
					view => view.prgItems.Visible)
				.DisposeWith(disposableRegistration);

			this.OneWayBind(ViewModel,
					viewModel => viewModel.IsLoading,
					view => view.btnLoad.Enabled, 
					value => !value)
				.DisposeWith(disposableRegistration);

			this.OneWayBind(ViewModel,
					viewModel => viewModel.HasItems,
					view => view.ckHasItems.Checked,
					value => value)
				.DisposeWith(disposableRegistration);

			this.OneWayBind(ViewModel,
					viewModel => viewModel.HasItemSelection,
					view => view.btnShowDetail.Enabled,
					value => value)
				.DisposeWith(disposableRegistration);

			this.OneWayBind(ViewModel,
					viewModel => viewModel.HasSubItems,
					view => view.lstDetails.Enabled,
					value => value)
				.DisposeWith(disposableRegistration);

			// see how ListBox DataSource works:
			// https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.listcontrol.displaymember?view=windowsdesktop-6.0
			// The DataSource contains a list of our models, and we use `DisplayMember` and `ValueMember` to display the data
			this.OneWayBind(ViewModel,
					viewModel => viewModel.ItemsFiltered,
					view => view.lstItems.DataSource,
					value =>
						{
							// debug tip: here you can inspect the reactive property emitted value 
							return value;
						})
				.DisposeWith(disposableRegistration);

			this.OneWayBind(ViewModel,
					viewModel => viewModel.SelectedItemTags,
					view => view.lstDetails.DataSource)
				.DisposeWith(disposableRegistration);

			this.Bind(ViewModel,
					viewModel => viewModel.SearchStartsWith,
					view => view.txtSearchStartsWith.Text)
				.DisposeWith(disposableRegistration);

			this.Bind(ViewModel,
					viewModel => viewModel.SearchEndsWith,
					view => view.txtSearchEndsWith.Text)
				.DisposeWith(disposableRegistration);

			/*
			 * WinForms Events
			 *
			 * This is the right way, but RxUI WinForms doesn't support winforms events that don't implement INotifyPropertyChanged.
			 */
			//this.Bind(ViewModel,
			//	vm => vm.SelectedItem,
			//	v => v.lstItems.SelectedItem
			//).DisposeWith(disposableRegistration);

			/*
			 * This is a temporary solution to listen to ListBox events.
			 * In this case we send a tuple with the index to make sure the emitted value is unique (read it as `change detection`) 
			 * and then the subscribe will get the next value.
			 * NB. this is not a bidirectional binding: if you want to update the SelectedValue from the ViewModel, take a look how it's done in `ItemsDDView`. 
			 */
			Observable.FromEventPattern(ev => lstItems.SelectedIndexChanged += ev, ev => lstItems.SelectedIndexChanged -= ev)
				.Select(_ => (item: lstItems.SelectedValue as Guid?, index: lstItems.SelectedIndex))
				.BindTo(ViewModel, vm => vm.SelectedItem);
		});
	}

	
}

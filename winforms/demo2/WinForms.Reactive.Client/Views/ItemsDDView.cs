using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;
using WinForms.Reactive.Client.Helpers;
using WinForms.Reactive.Client.Services;
using WinForms.Reactive.Client.ViewModels;

namespace WinForms.Reactive.Client.Views;

public partial class ItemsDDView : UserControl, IViewFor<ItemsDDViewModel>
{
	public ItemsDDViewModel ViewModel { get; set; }
	object IViewFor.ViewModel
	{
		get => ViewModel;
		set => ViewModel = (ItemsDDViewModel)value;
	}

	public ItemsDDView()
	{
		InitializeComponent();
		lstItems.DisplayMember = nameof(ItemDto.Name);
		lstItems.ValueMember = nameof(ItemDto.ItemId);

		cmbSortBy.DisplayMember = nameof(OrderByInfo<ItemsOrderBy>.Name);
		cmbSortBy.ValueMember = nameof(OrderByInfo<ItemsOrderBy>.Id);

		cmbSortBy.DataSource = new List<OrderByInfo<ItemsOrderBy>> {
			new() { Id = ItemsOrderBy.Id, Name = "Id" },
			new() { Id = ItemsOrderBy.Name, Name = "Name" },
		};

		ViewModel = new ItemsDDViewModel();

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

			// see how ListView DataSource works:
			// https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.listcontrol.displaymember?view=windowsdesktop-6.0
			// The DataSource contains a list of our models, and we use `DisplayMember` and `ValueMember` to display the data
			this.OneWayBind(ViewModel,
					viewModel => viewModel.Items,
					view => view.lstItems.DataSource,
					value =>
					{
						return value;
					})
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
			//	vm => vm.OrderBy,
			//	v => v.cmbSortBy.SelectedValue
			//).DisposeWith(disposableRegistration);

			// This is a temporary solution to listen to ListBox events.
			Observable.FromEventPattern(ev => cmbSortBy.SelectedIndexChanged += ev, ev => cmbSortBy.SelectedIndexChanged -= ev)
				.Select(_ => cmbSortBy.SelectedValue as ItemsOrderBy?)
				.BindTo(ViewModel, vm => vm.OrderBy);

			// And here we listen to OrderBy changes and then select the right element in the ComboBox.
			this.OneWayBind(ViewModel,
					viewModel => viewModel.OrderBy,
					view => view.cmbSortBy.SelectedIndex,
					value => cmbSortBy.Items.IndexOf<OrderByInfo<ItemsOrderBy>>(item => item.value.Id == value)
				)
				.DisposeWith(disposableRegistration);
		});
	}

}

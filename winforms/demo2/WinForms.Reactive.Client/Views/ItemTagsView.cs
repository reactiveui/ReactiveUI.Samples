using System.Reactive.Disposables;
using ReactiveUI;
using WinForms.Reactive.Client.Services;
using WinForms.Reactive.Client.ViewModels;

namespace WinForms.Reactive.Client.Views;

public partial class ItemTagsView : Form, IViewFor<ItemTagsViewModel>
{
	public ItemTagsViewModel ViewModel { get; set; }

	object IViewFor.ViewModel
	{
		get => ViewModel;
		set => ViewModel = (ItemTagsViewModel)value;
	}

	public ItemTagsView()
	{
		InitializeComponent();

		lstTags.DisplayMember = nameof(ItemTagDto.Name);
		lstTags.ValueMember = nameof(ItemTagDto.ItemTagId);

		ViewModel = new ItemTagsViewModel(Enumerable.Empty<ItemTagDto>());

		this.WhenActivated(disposableRegistration =>
		{
			this.BindCommand(ViewModel,
					vm => vm.ShowTag,
					v => v.btnShow)
				.DisposeWith(disposableRegistration);

			this.OneWayBind(ViewModel,
					viewModel => viewModel.Tags,
					view => view.lstTags.DataSource)
				.DisposeWith(disposableRegistration);

			this.OneWayBind(ViewModel,
					viewModel => viewModel.NumTags,
					view => view.lblCount.Text)
				.DisposeWith(disposableRegistration);

			this.OneWayBind(ViewModel,
					viewModel => viewModel.TagIds,
					view => view.lblIds.Text)
				.DisposeWith(disposableRegistration);
		});
	}

}

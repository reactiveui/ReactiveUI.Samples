using System.ComponentModel;
using System.Reactive.Disposables;
using System.Windows.Forms;
using ReactiveUI;

namespace ReactiveUIDemo;

// Visual Studio Designer does not support generic UserControls, so we cannot inherit from the generic `ReactiveUserControl<TViewModel>` and benefit from the RAD experience.
// if you are not interested in the Designer RAD experience, you can inherit from `ReactiveUserControl<NugetDetailsViewModel>` and remove the `IViewFor` interface members (ViewModel and IViewFor.ViewModel)
// You can take a look to the `ReactiveUserControl` implementation for more details.
public partial class NugetDetailsView : UserControl, IViewFor<NugetDetailsViewModel> // or NugetDetailsView : ReactiveUserControl<TViewModel> if you don't need to use the designer
{
    [Category("ReactiveUI")]
    [Description("The ViewModel.")]
    [Bindable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public NugetDetailsViewModel? ViewModel { get; set; }

    /// <inheritdoc/>
    object? IViewFor.ViewModel
    {
        get => ViewModel;
        set => ViewModel = (NugetDetailsViewModel?)value;
    }

    public NugetDetailsView()
    {
        InitializeComponent();

        this.WhenActivated(disposableRegistration =>
        {
            // Our 4th parameter we convert from Url into a BitmapImage. 
            // This is an easy way of doing value conversion using ReactiveUI binding.
            this.OneWayBind(ViewModel,
                    viewModel => viewModel.IconUrl,
                    view => view.iconImage.ImageLocation)
                .DisposeWith(disposableRegistration);

            this.OneWayBind(ViewModel,
                    viewModel => viewModel.Title,
                    view => view.titleRun.Text)
                .DisposeWith(disposableRegistration);

            this.OneWayBind(ViewModel,
                    viewModel => viewModel.Description,
                    view => view.descriptionRun.Text)
                .DisposeWith(disposableRegistration);

            this.BindCommand(ViewModel,
                    viewModel => viewModel.OpenPage,
                    view => view.titleRun)
                .DisposeWith(disposableRegistration);
        });
    }
}

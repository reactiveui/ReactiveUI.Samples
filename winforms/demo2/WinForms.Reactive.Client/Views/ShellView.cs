using ReactiveUI;
using WinForms.Reactive.Client.ViewModels;

namespace WinForms.Reactive.Client
{
	public partial class ShellView : Form, IViewFor<ShellViewModel>
	{
		public ShellView()
		{
			InitializeComponent();

			this.WhenActivated(b =>
			{
				// Bind router
				b(this.OneWayBind(ViewModel, vm => vm.Router, v => v.routedControlHost.Router));

				// Bind commands
				b(this.BindCommand(ViewModel, vm => vm.ShowItemsCommand, v => v.btnMainItems));
				b(this.BindCommand(ViewModel, vm => vm.ShowItemsDDCommand, v => v.btnMainItemsDD));
			});
		}

		public ShellViewModel ViewModel { get; set; }

		object IViewFor.ViewModel
		{
			get => ViewModel;
			set => ViewModel = (ShellViewModel)value;
		}
	}
}

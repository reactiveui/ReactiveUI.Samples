using ReactiveUI;
using ReactiveUI.XamForms;
using Sextant;
using SextantSample.ViewModels;

namespace SextantSample.Views
{
	public partial class SecondModalView : ReactiveContentPage<SecondModalViewModel>
    {
		public SecondModalView()
        {
            InitializeComponent();
			this.BindCommand(ViewModel, x => x.PushPage, x => x.PushPage);
            this.BindCommand(ViewModel, x => x.PopModal, x => x.PopModal);
        }
    }
}

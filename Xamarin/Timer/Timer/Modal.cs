using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Foundation;
using ReactiveUI;

namespace UI
{
    public partial class Modal : ViewControllerBase<ModalViewModel>
    {
        public Modal(IntPtr intPtr)
            : base(intPtr)
        {
            ViewModel = new ModalViewModel();
        }

        public ViewController Presenter { get; set; }

        /// <inheritdoc/>
        protected override void ComposeObservables()
        {
            this.WhenAnyObservable(x => x.ViewModel.Dismiss)
                .Subscribe(_ =>
                {
                    Presenter?.DismissViewController(this);
                })
                .DisposeWith(Bindings);
        }

        /// <inheritdoc/>
        protected override void BindControls()
        {
            this.OneWayBind(ViewModel, vm => vm.Id, modal => modal.Title)
                .DisposeWith(Bindings);

            this.OneWayBind(ViewModel, vm => vm.ButtonText, modal => modal.DismissButton.Title)
                .DisposeWith(Bindings);

            this.OneWayBind(ViewModel, vm => vm.Timer, view => view.TimerLabel.StringValue)
                .DisposeWith(Bindings);

            this.BindCommand(ViewModel, vm => vm.Dismiss, modal => modal.DismissButton)
                .DisposeWith(Bindings);
        }
    }
}

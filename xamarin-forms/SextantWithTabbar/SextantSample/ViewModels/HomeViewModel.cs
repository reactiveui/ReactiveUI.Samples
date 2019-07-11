using System;
using System.Diagnostics;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using Sextant;
using Splat;

namespace SextantSample.ViewModels
{
    public class HomeViewModel : ViewModelBase, IPageViewModel, ITabViewModel
    {
        public string Id => nameof(HomeViewModel);

        public ReactiveCommand<Unit, Unit> OpenModal
        {
            get;
            set;
        }

        public ReactiveCommand<Unit, Unit> PushPage
        {
            get;
            set;
        }

        public string TabTitle => Id;

        public string TabIcon => "";

        public HomeViewModel(IViewStackService viewStackService)
            : base(viewStackService)
        {
            OpenModal = ReactiveCommand
                .CreateFromObservable(() =>
                    ViewStackService.PushModal(new FirstModalViewModel(ViewStackService)),
                    outputScheduler: RxApp.MainThreadScheduler);

            PushPage = ReactiveCommand
                .CreateFromObservable(() =>
                    ViewStackService.PushPage(new RedViewModel(ViewStackService)),
                    outputScheduler: RxApp.MainThreadScheduler);

            OpenModal.Subscribe(x => Debug.WriteLine("PagePushed"));
        }
    }
}

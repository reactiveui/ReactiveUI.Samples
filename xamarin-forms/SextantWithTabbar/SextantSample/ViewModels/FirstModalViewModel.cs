using System.Reactive;
using ReactiveUI;
using Sextant;
using System;
using System.Diagnostics;

namespace SextantSample.ViewModels
{
	public class FirstModalViewModel : ViewModelBase, IPageViewModel
	{
		public ReactiveCommand<Unit, Unit> OpenModal
		{
			get;
			set;
		}

		public ReactiveCommand<Unit, Unit> PopModal
		{
			get;
			set;
		}

		public string Id => nameof(FirstModalViewModel);

		public FirstModalViewModel(IViewStackService viewStackService) : base(viewStackService)
		{
			OpenModal = ReactiveCommand
				.CreateFromObservable(() =>
	                this.ViewStackService.PushModal(new SecondModalViewModel(viewStackService)),
					outputScheduler: RxApp.MainThreadScheduler);

			PopModal = ReactiveCommand
				.CreateFromObservable(() =>
	                this.ViewStackService.PopModal(),
					outputScheduler: RxApp.MainThreadScheduler);

			OpenModal.Subscribe(x => Debug.WriteLine("PagePushed"));
			PopModal.Subscribe(x => Debug.WriteLine("PagePoped"));

		}
	}
}

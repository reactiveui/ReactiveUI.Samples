using System.ComponentModel;
using ReactiveUI;
using Sextant;
using Splat;

namespace SextantSample.ViewModels
{
	public class ViewModelBase : ReactiveObject, INotifyPropertyChanged, ISupportsActivation, IPageViewModel
    {
        public string Id => "ViewModelBase";

        public ViewModelActivator Activator { get; } = new ViewModelActivator();

        protected readonly IViewStackService ViewStackService;

		public ViewModelBase(IViewStackService viewStackService)
        {
            ViewStackService = viewStackService ?? Locator.Current.GetService<IViewStackService>();
        }


    }
}

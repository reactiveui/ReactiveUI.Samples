using System;
using System.Collections.Generic;
using ReactiveUI;
using Sextant;

namespace SextantSample.ViewModels
{
    public class MainNavigationViewModel : ViewModelBase
    {
        public List<Func<IViewStackService, TabViewModel>> TabViewModels
        {
            get => _tabViewModels;
            set => this.RaiseAndSetIfChanged(ref _tabViewModels, value);
        }

        private List<Func<IViewStackService, TabViewModel>> _tabViewModels;

        public MainNavigationViewModel(IViewStackService viewStackService = null)
            : base(viewStackService)
        {
            TabViewModels = new List<Func<IViewStackService, TabViewModel>>()
            {
                (customViewStack) => new TabViewModel("Home", "", customViewStack, () => new HomeViewModel(customViewStack)),
                (customViewStack) => new TabViewModel("Red", "", customViewStack, () => new RedViewModel(customViewStack)),
                (customViewStack) => new TabViewModel("Blue", "", customViewStack, () => new BlueViewModel(customViewStack))
            };
        }
    }
}

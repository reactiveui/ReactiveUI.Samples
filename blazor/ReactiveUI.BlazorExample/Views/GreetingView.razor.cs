using ReactiveUI.Blazor;
using ReactiveUI.BlazorExample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactiveUI.BlazorExample.Views
{
    public partial class GreetingView : ReactiveComponentBase<GreetingViewModel>
    {
        public GreetingView()
        {
            ViewModel = new GreetingViewModel();
        }

        public void Clear()
        {
            ViewModel.Clear.Execute().Subscribe();
        }
    }
}

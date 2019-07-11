using System;
using ReactiveUI;
using ReactiveUI.XamForms;
using SextantSample.ViewModels;
using Xamarin.Forms;

namespace SextantSample.Views
{
    public class TabView : ReactiveContentPage<TabViewModel>
    {
        public TabView()
        {
            this.WhenActivated(disposable =>
            {
                // Why do I need to add this here to make the VM WhenActivated Work?
            });
        }
    }
}


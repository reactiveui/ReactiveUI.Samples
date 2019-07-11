using System;
using System.Collections.Generic;
using ReactiveUI;
using ReactiveUI.XamForms;
using SextantSample.ViewModels;
using Xamarin.Forms;

namespace SextantSample.Views
{
    public partial class BlueView : ReactiveContentPage<BlueViewModel>
    {
        public BlueView()
        {
            InitializeComponent();
            this.BindCommand(ViewModel, x => x.PopModal, x => x.PopModal);
            this.BindCommand(ViewModel, x => x.PushPage, x => x.PushPage);
            this.BindCommand(ViewModel, x => x.PopPage, x => x.PopPage);
            this.BindCommand(ViewModel, x => x.PopToRoot, x => x.PopToRoot);
        }
    }
}

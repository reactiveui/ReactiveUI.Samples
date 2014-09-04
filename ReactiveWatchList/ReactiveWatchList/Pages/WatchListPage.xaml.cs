using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.XamForms;
using ReactiveWatchList.ViewModels;

namespace ReactiveWatchList.Pages
{
    public partial class WatchListPage 
    {
        public WatchListPage()
        {
            InitializeComponent();

            BindingContext = new WatchListViewModel();
        }
    }
}

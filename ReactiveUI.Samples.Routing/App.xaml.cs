using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using ReactiveUI.Samples.Routing.ViewModels;

namespace ReactiveUI.Samples.Routing
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public AppBootstrapper Bootstrapper = new AppBootstrapper();
    }
}

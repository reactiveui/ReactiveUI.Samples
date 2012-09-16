using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ReactiveUI.Routing;
using ReactiveUI.Samples.Routing.ViewModels;

namespace ReactiveUI.Samples.Routing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Since we only have one IScreen in the entire application, we can
            // just fetch it via GetService. The concrete implementation of this
            // class is the AppBootstrapper class.
            viewHost.Router = RxApp.GetService<IScreen>().Router;
        }
    }
}

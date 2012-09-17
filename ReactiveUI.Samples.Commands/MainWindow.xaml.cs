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
using Caliburn.Micro;

namespace ReactiveUI.Samples.Commands
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mvvmLightContainer.DataContext = new MVVMLight.MainViewModel();
            reactiveUIContainer.DataContext = new RxUI.MainViewModel();

            //binding the view to the VM manually, since we are not using the CaliburnBootstrapper   
            Caliburn.Micro.Bootstrapper b = new Bootstrapper(false);
            caliburnMicroContainer.DataContext = new CaliburnMicro.MainViewModel();
            //ViewModelBinder.Bind(new CaliburnMicro.MainViewModel(), caliburnMicroContainer, null);            
        }
    }
}

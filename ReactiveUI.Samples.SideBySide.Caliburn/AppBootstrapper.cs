using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using ReactiveUI.Samples.SideBySide.CaliburnMicro.ViewModels;

namespace ReactiveUI.Samples.SideBySide.CaliburnMicro
{
    public class AppBootstrapper:BootstrapperBase
    {
        public AppBootstrapper() { Initialize(); }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
    }
}

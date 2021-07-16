using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetail
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var bootstrapper = new AppBootstrapper();

            MainPage = new MainPage(bootstrapper.CreateMainViewModel());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

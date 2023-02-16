using System.Net.Http;
using FFImageLoading;
using FFImageLoading.Config;
using Fusillade;

namespace Cinephile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            ImageService.Instance.Initialize(new Configuration
            {
                HttpClient = new HttpClient(new RateLimitedHttpMessageHandler(new HttpClientHandler(), Priority.Background))
            });

            new AppBootstrapper();
            MainPage = AppBootstrapper.CreateMainPage();

            // I hate to do this, but honestly dont know a better way to styke the navbar
            ((NavigationPage)Current.MainPage).Style = Current.Resources["DefaultNavigationPageStyle"] as Style;
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

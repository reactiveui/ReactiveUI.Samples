namespace Cinephile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            new AppBootstrapper();
            MainPage = AppBootstrapper.CreateMainPage();
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

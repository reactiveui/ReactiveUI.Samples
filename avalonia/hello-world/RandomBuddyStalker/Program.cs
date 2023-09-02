using Avalonia;
using Avalonia.Controls;
using Avalonia.ReactiveUI;

namespace ReactiveAvalonia.RandomBuddyStalker {
    class Program {
        public static void Main(string[] args) {
            BuildAvaloniaApp().Start(AppMain, args);
        }

        public static AppBuilder BuildAvaloniaApp() {
            return AppBuilder
                .Configure<App>()
                .UseReactiveUI()
                .UsePlatformDetect()
                .LogToTrace();
        }

        private static void AppMain(Application app, string[] args) {
            app.Run(new MainView());
        }
    }
}

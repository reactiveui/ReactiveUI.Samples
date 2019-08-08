using Avalonia;
using Avalonia.Controls;
using Avalonia.Logging.Serilog;
using Avalonia.ReactiveUI;

namespace ReactiveAvalonia.HelloWorld {

    // You may want to start here:
    // https://reactiveui.net/docs/getting-started/

    class Program {
        // http://avaloniaui.net/docs/reactiveui/
        // https://github.com/AvaloniaUI/Avalonia/wiki/Application-lifetimes
        public static AppBuilder BuildAvaloniaApp() {
            return AppBuilder
                .Configure<App>()
                .UseReactiveUI()
                .UsePlatformDetect()
                .LogToDebug();
        }

        private static void AppMain(Application app, string[] args) {
            app.Run(new MainView());
        }

        public static void Main(string[] args) {
            BuildAvaloniaApp().Start(AppMain, args);
        }
    }
}

using Avalonia.Logging.Serilog;
using Avalonia.ReactiveUI;
using Avalonia;

namespace ReactiveUI.Samples.Suspension
{
    class Program
    {
        public static void Main(string[] args) => BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UseReactiveUI()
                .UsePlatformDetect()
                .LogToDebug();
    }
}

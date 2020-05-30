## [ReactiveUI.Samples.Suspension](https://github.com/reactiveui/ReactiveUI.Samples/tree/master/avalonia/suspension)

To read [navigation stack](https://reactiveui.net/docs/handbook/routing/) from disk, a suspension driver is required to support deserializing `IRoutableViewModel` interface implementations into more specific view model types, for `Newtonsoft.Json` this can be achieved by using `TypeNameHandling.All` json serialization setting. 
In the `App.OnFrameworkInitializationCompleted` method we initialize suspension stuff specific to our app. Don't forget to add `.UseReactiveUI()` and `.StartWithClassicDesktopLifetime()` to your app builder inside the `Program.cs` file.

Provides examples about:

1. [Suspension and Data Persistence](https://reactiveui.net/docs/handbook/data-persistence/)
2. [ViewModel first routing](https://reactiveui.net/docs/handbook/routing/)
3. [ReactiveCommands](https://reactiveui.net/docs/handbook/commands/)

Note: Avalonia produce and support the ReactiveUI plugin. You can get support on their [![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/AvaloniaUI/Avalonia?utm_campaign=pr-badge&utm_content=badge&utm_medium=badge&utm_source=badge)

<img width="350" src="https://hsto.org/webt/c2/pp/88/c2pp88h397pwscpwn-i8vnke6sw.gif">

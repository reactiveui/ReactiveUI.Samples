<a href="https://github.com/reactiveui/reactiveui">
  <img width="160" heigth="160" src="https://raw.githubusercontent.com/reactiveui/styleguide/master/logo/main.png">
</a>

# ReactiveUI.Samples

This repository will contain all of ReactiveUI samples.

## Xamarin Forms 

#### Cinephile

Example in Xamarin Forms (Android and iOS) shows you the upcoming movies from [the movie api](https://api.themoviedb.org/3)

Provides examples about: 

1. App's bootstrapping
2. ViewModel first routing
3. ListView integration
4. [ReactiveCommands](https://reactiveui.net/docs/handbook/commands/)
5. [ObservableAsPropertyHelper](https://reactiveui.net/docs/handbook/observable-as-property-helper/)

## Avalonia

#### ReactiveUI.Samples.Suspension

To read [navigation stack](https://reactiveui.net/docs/handbook/routing/) from disk, a suspension driver is required to support deserializing `IRoutableViewModel` interface implementations into more specific view model types, for `Newtonsoft.Json` this can be achieved by using `TypeNameHandling.All` json serialization setting. 
In the `App.OnFrameworkInitializationCompleted` method we initialize suspension stuff specific to our app. Don't forget to add `.UseReactiveUI()` and `.StartWithClassicDesktopLifetime()` to your app builder inside the `Program.cs` file.

Providers examples about:

1. [Suspension and Data Persistence](https://reactiveui.net/docs/handbook/data-persistence/)
2. [ViewModel first routing](https://reactiveui.net/docs/handbook/routing/)
3. [ReactiveCommands](https://reactiveui.net/docs/handbook/commands/)

<img width="300" src="https://hsto.org/webt/c2/pp/88/c2pp88h397pwscpwn-i8vnke6sw.gif">

## Razor

#### ReactiveUI.RazorExample

Building a web app with ReactiveUI and Razor Components.

<img width="500" src="https://i.gyazo.com/8bd953c633601e61c8a869631ba1d48e.gif">

Follow the [Razor Components tutorial](https://docs.microsoft.com/en-us/aspnet/core/razor-components/get-started?view=aspnetcore-3.0&tabs=visual-studio) on MSDN to get started. Heavily based on [@akourbat's work](https://github.com/akourbat/SampleRazorComponentsApp).
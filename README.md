<a href="https://github.com/reactiveui/reactiveui">
  <img width="90" heigth="90" src="https://raw.githubusercontent.com/reactiveui/styleguide/master/logo/main.png">
</a>

# ReactiveUI.Samples

This repository will contain all of ReactiveUI samples.

## Xamarin Forms

#### [Cinephile](https://github.com/reactiveui/ReactiveUI.Samples/tree/master/xamarin-forms/Cinephile)

Example in Xamarin Forms (Android and iOS) shows you the upcoming movies from [the movie api](https://api.themoviedb.org/3)

Provides examples about:

1. App's bootstrapping
2. [ViewModel first routing](https://reactiveui.net/docs/handbook/routing/)
3. ListView integration
4. [ReactiveCommands](https://reactiveui.net/docs/handbook/commands/)
5. [ObservableAsPropertyHelper](https://reactiveui.net/docs/handbook/observable-as-property-helper/)

## Xamarin Native

Examples provided:

1. Reactive Recycler View

## Avalonia

#### [ReactiveUI.Samples.Suspension](https://github.com/reactiveui/ReactiveUI.Samples/tree/master/avalonia)

To read [navigation stack](https://reactiveui.net/docs/handbook/routing/) from disk, a suspension driver is required to support deserializing `IRoutableViewModel` interface implementations into more specific view model types, for `Newtonsoft.Json` this can be achieved by using `TypeNameHandling.All` json serialization setting. 
In the `App.OnFrameworkInitializationCompleted` method we initialize suspension stuff specific to our app. Don't forget to add `.UseReactiveUI()` and `.StartWithClassicDesktopLifetime()` to your app builder inside the `Program.cs` file.

Provides examples about:

1. [Suspension and Data Persistence](https://reactiveui.net/docs/handbook/data-persistence/)
2. [ViewModel first routing](https://reactiveui.net/docs/handbook/routing/)
3. [ReactiveCommands](https://reactiveui.net/docs/handbook/commands/)

Note: Avalonia produce and support the ReactiveUI plugin. You can get support on their [![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/AvaloniaUI/Avalonia?utm_campaign=pr-badge&utm_content=badge&utm_medium=badge&utm_source=badge)

<img width="350" src="https://hsto.org/webt/c2/pp/88/c2pp88h397pwscpwn-i8vnke6sw.gif">

## Testing

#### [ReactiveUI.Samples.Testing.SimpleViewModels](https://github.com/reactiveui/ReactiveUI.Samples/tree/master/testing)

Illustrates how to write testable and maintainable [view models](https://reactiveui.net/docs/handbook/view-models/) using `ReactiveUI.Testing`, `XUnit` and `Microsoft.Reactive.Testing` libraries. See [related documentation](https://reactiveui.net/docs/handbook/testing/). Contains immediate scheduling examples to make the tests run even faster by mocking long-running operations.

```cs
new TestScheduler().With(scheduler =>
{
    var fixture = new WebCallViewModel(new ImmediateWebService());
    fixture.InputText = "hi";

    // Run the clock forward to 800 ms. 
    // At that point, nothing should have happened.
    scheduler.AdvanceToMs(799);
    Assert.Equal(string.Empty, fixture.ResultText);

    // Run the clock 1 tick past and the result should show up.
    scheduler.AdvanceToMs(801);
    Assert.Equal("result hi", fixture.ResultText);
});
```

## Universal Windows Platform

#### [ReactiveUI.UwpRouting](https://github.com/reactiveui/ReactiveUI.Samples/tree/master/uwp)

Provides examples about [ReactiveUI routing](https://reactiveui.net/docs/handbook/routing/) for Universal Windows Platform.

<img width="400" src="https://i.gyazo.com/b5356b350c3ce2084f50d9ba534343a8.gif">

## Blazor

#### [ReactiveUI.RazorExample](https://github.com/reactiveui/ReactiveUI.Samples/tree/master/blazor)

Building a web app with ReactiveUI and Razor Components.

<img width="500" src="https://i.gyazo.com/8bd953c633601e61c8a869631ba1d48e.gif">

Follow the [Blazor tutorial](https://docs.microsoft.com/en-us/aspnet/core/tutorials/build-your-first-blazor-app?view=aspnetcore-3.1&tabs=visual-studio) on MSDN to get started. Heavily based on [@akourbat's work](https://github.com/akourbat/SampleRazorComponentsApp).

## More Avalonia samples

Self-contained multiplatform samples to help understanding: [ReactiveX](http://reactivex.io), [ReactiveUI](https://reactiveui.net), [Avalonia UI](https://avaloniaui.net). Featuring links to original reference material for each fresh chunk of code, e.g.

```cs
// https://reactiveui.net/docs/handbook/events/#how-do-i-convert-my-own-c-events-into-observables
Observable
    .FromEventPattern(wndMain, nameof(wndMain.Closing))
    .Subscribe(_ => Console.WriteLine("Main window closing..."))
    .DisposeWith(disposables);
```

#### [Hello World](https://github.com/reactiveui/ReactiveUI.Samples/tree/master/reactive-avalonia/HelloWorld)

Uses a finite observable stream of timer ticks. At each tick a new
greeting is displayed. The sample can be a template for ReactiveUI + Avalonia
applications.

*Topics: View, ViewModel, (de)activation, reactive property, type-safe bindings,
WhenAnyValue, observable timer, UI thread and schedulers, window event.*

<img  width="200" src="https://www.dropbox.com/s/ykhs4f322fwi7sx/HelloReactiveWorld_Trailer.gif?raw=1" />

#### [Random Buddy Stalker](https://github.com/reactiveui/ReactiveUI.Samples/tree/master/reactive-avalonia/RandomBuddyStalker)

Shows how to use async/await in a ReactiveUI context. It calls a
dummy [(but real)](https://reqres.in) RESTful API.

*Topics: command binding, ReactiveUI.Fody, Rx event pattern, async/await,
timeout, json, Flurl.*

<img  width="200" src="https://www.dropbox.com/s/bzt56v87b6hzpai/RandomBuddyStalker_Trailer.gif?raw=1" />

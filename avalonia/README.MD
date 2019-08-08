# ReactiveUI AvaloniaUI Samples

- [Hello World](hello-world/HelloWorld)

- [ReactiveUI Suspension](suspension)

- [Random Buddy Stalker](hello-world/RandomBuddyStalker)

### More Avalonia samples

Self-contained multiplatform samples to help understanding: [ReactiveX](http://reactivex.io), [ReactiveUI](https://reactiveui.net), [Avalonia UI](https://avaloniaui.net). Featuring links to original reference material for each fresh chunk of code, e.g.

```cs
// https://reactiveui.net/docs/handbook/events/#how-do-i-convert-my-own-c-events-into-observables
Observable
    .FromEventPattern(wndMain, nameof(wndMain.Closing))
    .Subscribe(_ => Console.WriteLine("Main window closing..."))
    .DisposeWith(disposables);
```

module Main

open System
open CP.FSharp.Core.Wpf

type App = XAML<"App.xaml">

[<STAThread>]
[<EntryPoint>]
let main argv =
    App().Run()

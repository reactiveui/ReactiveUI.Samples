module Main

open System
open FsXaml

type App = XAML<"App.xaml">

[<EntryPoint;STAThread>]
let main argv =
    App().Run()

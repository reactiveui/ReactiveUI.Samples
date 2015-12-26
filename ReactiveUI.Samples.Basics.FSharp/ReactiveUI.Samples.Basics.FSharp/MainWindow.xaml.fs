namespace ViewModels

open System
open System.Windows
open FSharp.ViewModule
open FSharp.ViewModule.Validation
open FsXaml

type MainView = XAML<"MainWindow.xaml", true>

type MainViewModel() as self = 
    inherit ViewModelBase()    
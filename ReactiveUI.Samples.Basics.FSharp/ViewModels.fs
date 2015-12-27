namespace ReactiveUI.Samples.Basics.FSharp.ViewModels

open System
open System.ComponentModel.DataAnnotations
open System.Linq.Expressions
open System.Reactive.Concurrency
open System.Reactive.Linq
open System.Threading
open System.Threading.Tasks
open System.Windows
open System.Windows.Input

open Microsoft.FSharp.Quotations

open ReactiveUI
open Splat

open ReactiveUI.Samples.Basics

module Utility =
    // From http://stackoverflow.com/questions/2682475/converting-f-quotations-into-linq-expressions
    /// Converts a F# Expression to a LINQ Lambda
    let toLambda (exp:Expr) =
        let linq = Microsoft.FSharp.Linq.RuntimeHelpers.LeafExpressionConverter.QuotationToExpression exp :?> MethodCallExpression
        linq.Arguments.[0] :?> LambdaExpression

    /// Converts a Lambda quotation into a Linq Lamba Expression with 1 parameter
    let toLinq (exp : Expr<'a -> 'b>) =
        let lambda = toLambda exp
        Expression.Lambda<Func<'a, 'b>>(lambda.Body, lambda.Parameters)

type PersonViewModel() as this =
    inherit ReactiveValidatedObject()

    let age = ref Unchecked.defaultof<int>
    let isValid = ref false

    do
        this.ValidationObservable.Subscribe(fun _ -> this.IsValid <- this.IsObjectValid()) |> ignore
    
    member __.IsAgeValid ageToCheck = ageToCheck >= 0 && ageToCheck <= 120

    [<ValidatesViaMethod(AllowBlanks = false, AllowNull = false, Name = "IsAgeValid", ErrorMessage = "Please enter a valid age 0..120")>]
    member __.Age
        with get () = !age
        and set value = this.RaiseAndSetIfChanged(age, value, "Age") |> ignore

    member __.IsValid
        with get () = !isValid
        and set value = this.RaiseAndSetIfChanged(isValid, value, "IsValid") |> ignore

type CalculatorViewModel() as this =
    inherit ReactiveValidatedObject()

    let mutable number = ref Unchecked.defaultof<int>
    let mutable result = ref Unchecked.defaultof<int>

    let cache = new MemoizingMRUCache<_, _>((fun x ctx -> Thread.Sleep 1000; x * 10), 5)

    let calculateCommand = ReactiveCommand.CreateAsyncTask(fun o ->
        Task.Factory.StartNew(fun () ->
            match cache.TryGet this.Number with
            | true, cached ->
                this.Result <- 0
                Thread.Sleep 1000
                this.Result <- cached
            | false, _ ->
                let top = cache.Get this.Number
                [ 0 .. top ]
                |> List.iter (fun n -> this.Result <- n; Thread.Sleep 1000)
        )
    )

    [<Required>]
    member __.Number
        with get () = !number
        and set value = this.RaiseAndSetIfChanged(number, value, "Number") |> ignore
    
    member __.Result
        with get () = !result
        and set value = this.RaiseAndSetIfChanged(result, value, "Result") |> ignore
    
    member __.CalculateCommand = calculateCommand :> ICommand

type MainViewModel() as this =
    inherit ReactiveObject()


    let progress = ref Unchecked.defaultof<int>
    let slowProgress = ref Unchecked.defaultof<int>
    let slowProgress2 = ref Unchecked.defaultof<int>

    let person = ref (PersonViewModel())
    let calculator = ref (CalculatorViewModel())

    do
        RxApp.MainThreadScheduler <- DispatcherScheduler(Application.Current.Dispatcher)

        Task.Factory.StartNew(fun () ->
            while true do
                if this.Progress = 100 then this.Progress <- 0

                this.Progress <- this.Progress + 1

                Thread.Sleep(if this.Progress % 10 = 0 then 2000 else 400)
        )
        |> ignore

        this.ObservableForProperty(Utility.toLinq <@ fun vm -> vm.Progress @>)
            .Throttle(TimeSpan.FromSeconds 1.)
            .Subscribe(fun _ -> this.SlowProgress <- this.Progress)
        |> ignore

        this.WhenAny(Utility.toLinq <@ fun vm -> vm.Progress @>, fun _ -> true)
            .Throttle(TimeSpan.FromSeconds 1., RxApp.MainThreadScheduler)
            .Subscribe(fun _ -> this.SlowProgress2 <- this.Progress)
        |> ignore

    member __.Progress
        with get () = !progress
        and set (value : int) = this.RaiseAndSetIfChanged(progress, value, "Progress") |> ignore

    member __.SlowProgress
        with get () = !slowProgress
        and set (value : int) = this.RaiseAndSetIfChanged(slowProgress, value, "SlowProgress") |> ignore

    member __.SlowProgress2
        with get () = !slowProgress2
        and set (value : int) = this.RaiseAndSetIfChanged(slowProgress2, value, "SlowProgress2") |> ignore

    member __.Person
        with get () = !person
        and set value = this.RaiseAndSetIfChanged(person, value, "Person") |> ignore

    member __.Calculator
        with get () = !calculator
        and set value = this.RaiseAndSetIfChanged(calculator, value, "Calculator") |> ignore

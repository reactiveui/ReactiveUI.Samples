# ReactiveUI Testing Samples

## [ReactiveUI.Samples.Testing.SimpleViewModels](https://github.com/reactiveui/ReactiveUI.Samples/tree/master/testing)

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
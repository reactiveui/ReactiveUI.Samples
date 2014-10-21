﻿
using System;
using System.Reactive.Linq;

namespace ReactiveUI.Samples.Testing.SimpleViewModels
{
    /// <summary>
    /// A class that simulates a call to a web service, which is expected to
    /// take some time. We also do some work so that we don't flood the
    /// web service each time the user updates the input.
    /// </summary>
    public class WebCallViewModel : ReactiveObject
    {
        string _InputText;
        public string InputText
        {
            get { return _InputText; }
            set { this.RaiseAndSetIfChanged(ref _InputText, value); }
        }

        public string ResultText { get { return _ResultTextOAPH.Value; } }
        private ObservableAsPropertyHelper<string> _ResultTextOAPH;

        IReactiveCommand<string> _doWebCall;

        /// <summary>
        /// Setup the lookup logic, and use the interface to do the web call.
        /// </summary>
        /// <param name="caller"></param>
        public WebCallViewModel(IWebCaller caller)
        {
            // Do a search when nothing new has been entered for 800 ms and it isn't
            // an empty string... and don't search for the same thing twice.

            var newSearchNeeded = this.WhenAny(p => p.InputText, x => x.Value)
                .Throttle(TimeSpan.FromMilliseconds(800), RxApp.TaskpoolScheduler)
                .DistinctUntilChanged()
                .Where(x => !string.IsNullOrWhiteSpace(x));

            _doWebCall = ReactiveCommand.CreateAsyncObservable(x => caller.GetResult(x as string));

            newSearchNeeded.InvokeCommand(_doWebCall);

            // Run the web call and save the results back to the UI when done.
            var webResults =
                _doWebCall.ExecuteAsync();

            // The results are stuffed into the property, on the proper thread
            // (ToProperty takes care of that) when done. We never want the property to
            // be null, so we give it an initial value of "".
            webResults
                .ToProperty(this, x => x.ResultText, out _ResultTextOAPH, "");
        }
    }
}

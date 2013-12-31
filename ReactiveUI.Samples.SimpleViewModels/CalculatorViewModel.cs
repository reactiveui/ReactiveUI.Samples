using System;
using System.Reactive.Linq;

namespace ReactiveUI.Samples.SimpleViewModels
{
    /// <summary>
    /// A view model with some straight forward calculations. There are no
    /// async operations involve, nor are there any delays or other time related
    /// calls.
    /// Operation: The user enters text into the input text field.
    /// If the text doesn't contain numbers, then an error message is shown in the ErrorText field
    /// Otherwise the number x2 is shown in the ResultText field.
    /// The ErrorText and ResultText fields should be empty when nothing is in InputText.
    /// </summary>
    public class CalculatorViewModel : ReactiveObject
    {
        string _InputText;
        public string InputText
        {
            get { return _InputText; }
            set { this.RaiseAndSetIfChanged(ref _InputText, value); }
        }

        public string ErrorText { get; private set; }
        private ObservableAsPropertyHelper<string> _ErrorTextOAPH;

        public string ResultText { get; private set; }
        private ObservableAsPropertyHelper<string> _ResultTextOAPH;

        public CalculatorViewModel()
        {
            var haveInput = this.WhenAny(x => x.InputText, x => x.Value)
                .Where(x => !string.IsNullOrEmpty(x));

            // Convert into a stream of parsed integers, or null if we fail.
            var parsedIntegers = haveInput
                .Select(x =>
                {
                    int val;
                    return int.TryParse(x, out val) ? (int?)val : (int?)null;
                });

            // Now, the error text
            parsedIntegers
                .Select(x => x.HasValue ? "" : "Error")
                .Subscribe(x => { ErrorText = x; });

            // And the result, which is *2 of the input.
            parsedIntegers
                .Select(x => x.HasValue ? (x.Value * 2).ToString() : "")
                .Subscribe(x => { ResultText = x; });
            // Woudd like be using the following line instead of above, but it doesn't work:
            // ToProperty(this, x => x.ResultText, out _ResultTextOAPH);
        }
    }
}

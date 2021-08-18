using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading;
using ReactiveUI;
using Sextant;
using Splat;

namespace Navigation.Parameters
{
    public class ReceivedViewModel : ViewModelBase
    {
        private string _receivedParameter;

        public override string Id => "Received Parameter";

        public string ReceivedParameter
        {
            get => _receivedParameter;
            set => this.RaiseAndSetIfChanged(ref _receivedParameter, value);
        }

        public override IObservable<Unit> WhenNavigatingTo(INavigationParameter parameter)
        {
            if (parameter.ContainsKey("parameter"))
            {
                var received = parameter["parameter"];
                ReceivedParameter = received.ToString();
            }

            return base.WhenNavigatedTo(parameter);
        }
    }
}

using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading;
using ReactiveUI;
using ReactiveUI.Validation.Abstractions;
using ReactiveUI.Validation.Contexts;
using ReactiveUI.Validation.Extensions;
using Sextant;
using Splat;
using Xamarin.Forms;

namespace Navigation.Parameters
{
    public class PassViewModel : ViewModelBase, ISupportsValidation
    {
        private string _passingParameter;

        public PassViewModel()
        {
            var navigationService = Locator
                            .Current
                            .GetService<IParameterViewStackService>();
            Navigate =
                ReactiveCommand
                .CreateFromObservable(
                    () => navigationService
                            .PushPage(new ReceivedViewModel(), new NavigationParameter { { "parameter", PassingParameter } }), ValidationContext.Valid, RxApp.MainThreadScheduler);

            this.ValidationRule(
            viewModel => viewModel.PassingParameter,
            parameter => !string.IsNullOrWhiteSpace(parameter) && int.TryParse(parameter, out int result),
            "You must specify a number.");
        }

        public override string Id => "Pass Parameter";

        public string PassingParameter
        {
            get => _passingParameter;
            set => this.RaiseAndSetIfChanged(ref _passingParameter, value);
        }

        public ReactiveCommand<Unit, Unit> Navigate { get; private set; }

        public ValidationContext ValidationContext { get; } = new ValidationContext();
    }
}


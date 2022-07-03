using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Windows.Input;
using System.Reactive.Linq;
using System.Reactive;
using ReactiveUI;
using Splat;

namespace ReactiveUI.Samples.Suspension.ViewModels
{
    [DataContract]
    public class LoginViewModel : ReactiveObject, IRoutableViewModel
    {
        private readonly ReactiveCommand<Unit, Unit> _login;
        private string? _password;
        private string? _username;

        public LoginViewModel(IScreen? screen = null)
        {
            HostScreen = Locator.Current.GetService<IScreen>()!;

            var canLogin = this
                .WhenAnyValue(
                    x => x.Username,
                    x => x.Password,
                    (user, pass) => !string.IsNullOrWhiteSpace(user) &&
                                    !string.IsNullOrWhiteSpace(pass));

            _login = ReactiveCommand.CreateFromTask(
                () => Task.Delay(1000),
                canLogin);
        }

        public IScreen HostScreen { get; }

        public string UrlPathSegment => "/login";

        public ICommand Login => _login;

        [DataMember]
        public string? Username
        {
            get => _username;
            set => this.RaiseAndSetIfChanged(ref _username, value);
        }

        public string? Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }
    }
}

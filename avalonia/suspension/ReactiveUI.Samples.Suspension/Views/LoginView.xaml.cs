using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using System.Reactive.Disposables;
using ReactiveUI.Samples.Suspension.ViewModels;
using ReactiveUI;

namespace ReactiveUI.Samples.Suspension.Views
{
    public sealed class LoginView : ReactiveUserControl<LoginViewModel>
    {
        public LoginView()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}


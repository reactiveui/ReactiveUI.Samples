using System.Reactive;
using ReactiveUI;

namespace WinForms.Reactive.Client.ViewModels;

public class ShellViewModel : ReactiveObject, IScreen
{
	public RoutingState Router { get; }
	
	// Commands
	public ReactiveCommand<Unit, IRoutableViewModel> ShowItemsCommand { get; }
	public ReactiveCommand<Unit, IRoutableViewModel> ShowItemsDDCommand { get; }

	public ShellViewModel()
	{
		Router = new RoutingState();

		ShowItemsCommand = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new ItemsViewModel()));
		ShowItemsDDCommand = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new ItemsDDViewModel()));
	}

}

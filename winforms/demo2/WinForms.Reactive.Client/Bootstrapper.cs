using System.Reactive;
using System.Reflection;
using ReactiveUI;
using Splat;
using WinForms.Reactive.Client.Interactions;
using WinForms.Reactive.Client.Services;
using WinForms.Reactive.Client.ViewModels;

namespace WinForms.Reactive.Client;

public class Bootstrapper
{
	public Bootstrapper()
	{
		ConfigureServices();
		ConfigureInteractions();
	}

	private void ConfigureServices()
	{
		Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetCallingAssembly());

		Locator.CurrentMutable.RegisterLazySingleton(() => new ItemsService(), typeof(IItemsService));
	}

	private void ConfigureInteractions()
	{
		MessageInteractions.ShowMessage.RegisterHandler(context =>
		{
			MessageBox.Show(context.Input);
			context.SetOutput(Unit.Default);
		});

		MessageInteractions.AskConfirmation.RegisterHandler(context =>
		{
			var dlgResult = MessageBox.Show(context.Input, "Confirmation required", MessageBoxButtons.YesNoCancel);
			context.SetOutput(dlgResult == DialogResult.Yes);
		});
	}

	public void Run()
	{
		var viewModel = new ShellViewModel();
		Locator.CurrentMutable.RegisterConstant(viewModel, typeof(IScreen));
		var view = ViewLocator.Current.ResolveView(new ShellViewModel());
		view.ViewModel = viewModel;
		Application.Run((Form)view);
	}
}

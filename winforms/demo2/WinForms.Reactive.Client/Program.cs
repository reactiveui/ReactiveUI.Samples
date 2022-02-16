using ReactiveUI;
using WinForms.Reactive.Client.Helpers;

namespace WinForms.Reactive.Client;

internal static class Program
{

	/// <summary>
	///  The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main()
	{
		// To customize application configuration such as set high DPI settings or default font,
		// see https://aka.ms/applicationconfiguration.
		ApplicationConfiguration.Initialize();

		RxApp.DefaultExceptionHandler = new CustomObservableExceptionHandler();

		var bootstrapper = new Bootstrapper();
		bootstrapper.Run();
	}

}

using System;
using System.Reflection;
using System.Windows.Forms;
using ReactiveUI;
using Splat;

namespace ReactiveUIDemo;

internal static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // A helper method that will register all classes that derive off IViewFor 
        // into our dependency injection container. ReactiveUI uses Splat for it's 
        // dependency injection by default, but you can override this if you like.
        Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetCallingAssembly());

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        Application.Run(new MainWindow());
    }
}

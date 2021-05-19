using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ReactiveUI.UwpRouting.Views;
using _Window = Windows.UI.Xaml.Window;

namespace ReactiveUI.UwpRouting
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            ConfigureFilters(global::Uno.Extensions.LogExtensionPoint.AmbientLoggerFactory);

            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            if (!(_Window.Current.Content is Frame rootFrame))
            {
                rootFrame = new Frame();
                rootFrame.NavigationFailed += OnNavigationFailed;
                _Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated != false)
                return;
            if (rootFrame.Content == null)
                rootFrame.Navigate(typeof(MainView), e.Arguments);
            _Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Configures global logging
        /// </summary>
        /// <param name="factory"></param>
        static void ConfigureFilters(ILoggerFactory factory)
        {
            ////			factory
            ////				.WithFilter(new FilterLoggerSettings
            ////					{
            ////						{ "Uno", LogLevel.Warning },
            ////						{ "Windows", LogLevel.Warning },

            ////						// Debug JS interop
            ////						// { "Uno.Foundation.WebAssemblyRuntime", LogLevel.Debug },

            ////						// Generic Xaml events
            ////						// { "Windows.UI.Xaml", LogLevel.Debug },
            ////						// { "Windows.UI.Xaml.VisualStateGroup", LogLevel.Debug },
            ////						// { "Windows.UI.Xaml.StateTriggerBase", LogLevel.Debug },
            ////						// { "Windows.UI.Xaml.UIElement", LogLevel.Debug },

            ////						// Layouter specific messages
            ////						// { "Windows.UI.Xaml.Controls", LogLevel.Debug },
            ////						// { "Windows.UI.Xaml.Controls.Layouter", LogLevel.Debug },
            ////						// { "Windows.UI.Xaml.Controls.Panel", LogLevel.Debug },
            ////						// { "Windows.Storage", LogLevel.Debug },

            ////						// Binding related messages
            ////						// { "Windows.UI.Xaml.Data", LogLevel.Debug },

            ////						// DependencyObject memory references tracking
            ////						// { "ReferenceHolder", LogLevel.Debug },
            ////					}
            ////				)
            ////#if DEBUG
            ////				.AddConsole(LogLevel.Debug);
            ////#else
            ////				.AddConsole(LogLevel.Information);
            ////#endif
        }
    }
}

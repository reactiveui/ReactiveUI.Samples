// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MS-PL license.
// See the LICENSE file in the project root for more information.

using System;
using Features;
using Foundation;
using Serilog;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace App.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
        public override UIWindow Window
        {
            get;
            set;
        }

        /// <summary>
        /// The application is entering into background state.
        /// </summary>
        public override void DidEnterBackground(UIApplication application)
        {
            Log.Information("Application entering background state");
        }

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            UIApplication.SharedApplication.SetStatusBarHidden(true, true);

#if ENABLE_TEST_CLOUD
            Xamarin.Calabash.Start();
#endif

            global::Xamarin.Forms.Forms.Init();

            var log = new LoggerConfiguration()
                .Enrich.WithThreadId()
                .WriteTo.NSLog()
                .CreateLogger();

            UIApplication.SharedApplication.SetMinimumBackgroundFetchInterval(UIApplication.BackgroundFetchIntervalMinimum);

            LoadApplication(new Features.App());

            return base.FinishedLaunching(app, options);
        }

        /// <summary>
        /// The application is active.
        /// </summary>
        public override void OnActivated(UIApplication application)
        {
            Log.Information("Application is active");
        }

        /// <summary>
        /// The application is moving to inactive state.
        /// </summary>
        public override void OnResignActivation(UIApplication application)
        {
            Log.Information("Application moving to inactive state");
        }

        /// <summary>
        /// Invoked by the operating system to allow application to "download data" aka update location.
        /// </summary>
        /// <remarks>period is defined by  UIApplication.SharedApplication.SetMinimumBackgroundFetchInterval and there is an operating system limit to prevent running more often than once every 15 minutes.</remarks>
        public override void PerformFetch(UIApplication application, System.Action<UIBackgroundFetchResult> completionHandler)
        {
            Log.Information("Application background fetch called");
            try {
                Log.Information("Application background refresh succeeded");
                completionHandler(UIBackgroundFetchResult.NewData);
            } catch (Exception ex) {
                Log.Error(ex, "Application background refresh failed");
                completionHandler(UIBackgroundFetchResult.Failed);
            }
        }

        /// <summary>
        /// The application is about to enter the foreground.
        /// </summary>
        public override void WillEnterForeground(UIApplication application)
        {
            Log.Information("Application will enter the foreground");
        }

        /// <remarks>the iOS platform provides no guarantees that this will run</remarks>
        public override void WillTerminate(UIApplication application)
        {
            Log.Information("Application is terminating");
        }

    }
}

﻿using System;
using ReactiveUI;
using ReactiveUI.Xaml;

namespace ReactiveUI.Samples.Routing.ViewModels
{
    // It's usually a good idea to create an interface for every ViewModel and
    // reference that instead of the implementation. This makes creating fake
    // versions or design-time versions of ViewModels much easier.
    public interface IWelcomeViewModel : IRoutableViewModel
    {
        ReactiveCommand HelloWorld { get; }
    }

    public class WelcomeViewModel : ReactiveObject, IWelcomeViewModel
    {
        /* COOLSTUFF: What is UrlPathSegment
         * 
         * Imagine that the router state is like the path of the URL - what 
         * would the path look like for this particular page? Maybe it would be
         * the current user's name, or an "id". In this case, it's just a 
         * constant. You can get the whole path via 
         * IRoutingState.GetUrlForCurrentRoute.
         */
        public string UrlPathSegment {
            get { return "welcome"; }
        }

        public IScreen HostScreen { get; protected set; }
        public ReactiveCommand HelloWorld { get; protected set; }

        /* COOLSTUFF: Why the Screen here?
         *
         * Every RoutableViewModel has a pointer to its IScreen. This is really
         * useful in a unit test runner, because you can create a dummy screen,
         * invoke Commands / change Properties, then test to see if you navigated
         * to the correct new screen 
         */
        public WelcomeViewModel(IScreen screen)
        {
            HostScreen = screen;

            /* COOLSTUFF: Where's the Execute handler?
             * 
             * We want this command to display a MessageBox. However, 
             * displaying a MessageBox is a very View'y thing to do. Instead, 
             * the ViewModel is going to create the ReactiveCommand and the
             * *View* is going to Subscribe to it. That way, we can test in
             * the Unit Test runner that HelloWorld is Execute'd at the right
             * times, but still display the MessageBox when the code runs 
             * normally,
             */

            HelloWorld = new ReactiveCommand();
        }
    }
}
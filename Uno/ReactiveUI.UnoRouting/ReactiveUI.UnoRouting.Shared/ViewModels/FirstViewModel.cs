using System;

namespace ReactiveUI.UnoRouting.ViewModels
{
    /// <summary>
    /// FirstViewModel.
    /// </summary>
    public class FirstViewModel : ReactiveObject, IRoutableViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FirstViewModel"/> class.
        /// </summary>
        /// <param name="screen">The screen.</param>
        public FirstViewModel(IScreen screen) => HostScreen = screen;

        /// <summary>
        /// Gets the IScreen that this ViewModel is currently being shown in. This
        /// is usually passed into the ViewModel in the Constructor and saved
        /// as a ReadOnly Property.
        /// </summary>
        public IScreen HostScreen { get; }

        /// <summary>
        /// Gets a string token representing the current ViewModel, such as 'login' or 'user'.
        /// </summary>
        public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);
    }
}

using System.Reactive;
using ReactiveUI.UnoRouting.Views;
using Splat;

namespace ReactiveUI.UnoRouting.ViewModels
{
    /// <summary>
    /// MainViewModel.
    /// </summary>
    public class MainViewModel : ReactiveObject, IScreen
    {
        /// <summary>
        /// Gets the Router associated with this Screen.
        /// </summary>
        public RoutingState Router { get; } = new RoutingState();

        /// <summary>
        /// Gets the go next.
        /// </summary>
        /// <value>
        /// The go next.
        /// </value>
        public ReactiveCommand<Unit, IRoutableViewModel> GoNext { get; }

        /// <summary>
        /// Gets the go back.
        /// </summary>
        /// <value>
        /// The go back.
        /// </value>
        public ReactiveCommand<Unit, IRoutableViewModel> GoBack => Router.NavigateBack;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            // Router uses Splat.Locator to resolve views for
            // view models, so we need to register our views
            // using Locator.CurrentMutable.Register* methods.
            //
            Locator.CurrentMutable.Register(() => new FirstView(), typeof(IViewFor<FirstViewModel>));

            // Manage the routing state. Use the Router.Navigate.Execute
            // command to navigate to different view models.
            //
            // Note, that the Navigate.Execute method accepts an instance
            // of a view model, this allows you to pass parameters to
            // your view models, or to reuse existing view models.
            //
            GoNext = ReactiveCommand.CreateFromObservable(
                () => Router.Navigate.Execute(new FirstViewModel(this))
            );
        }
    }
}

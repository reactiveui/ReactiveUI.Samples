using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using ReactiveUI.UnoRouting.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ReactiveUI.UnoRouting.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FirstView : Page, IViewFor<FirstViewModel>
    {
        /// <summary>
        /// The view model property
        /// </summary>
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty
            .Register(nameof(ViewModel), typeof(FirstViewModel), typeof(FirstView), null);

        /// <summary>
        /// Initializes a new instance of the <see cref="FirstView"/> class.
        /// </summary>
        public FirstView()
        {
            InitializeComponent();
            this.WhenActivated(disposables => { });
        }

        /// <summary>
        /// Gets or sets the ViewModel corresponding to this specific View. This should be
        /// a DependencyProperty if you're using XAML.
        /// </summary>
        public FirstViewModel ViewModel
        {
            get => (FirstViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (FirstViewModel)value;
        }
    }
}

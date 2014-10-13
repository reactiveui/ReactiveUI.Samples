using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ReactiveUI.Samples.Routing.ViewModels;

namespace ReactiveUI.Samples.Routing.Views
{
    /// <summary>
    /// Interaction logic for WelcomeView.xaml
    /// </summary>
    public partial class WelcomeView : UserControl, IViewFor<IWelcomeViewModel>
    {
        public WelcomeView()
        {
            InitializeComponent();

            this.WhenAnyValue(x => x.ViewModel).BindTo(this, x => x.DataContext);

            Observable.FromEventPattern<DependencyPropertyChangedEventHandler, DependencyPropertyChangedEventArgs>(
                x => DataContextChanged += x,
                x => DataContextChanged -= x)
                .Subscribe((e) => {
                    IWelcomeViewModel vm = e.EventArgs.NewValue as IWelcomeViewModel;

                    if (vm != null)
                        vm.HelloWorld.Subscribe(param => MessageBox.Show("It worked!!!"));
                });
        }

        public IWelcomeViewModel ViewModel {
            get { return (IWelcomeViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(IWelcomeViewModel), typeof(WelcomeView), new PropertyMetadata(null));

        object IViewFor.ViewModel {
            get { return ViewModel; }
            set { ViewModel = (IWelcomeViewModel)value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Caliburn.Micro;


namespace ReactiveUI.Samples.Commands.CaliburnMicro
{
    public class MainViewModel : Screen, IReactiveNotifyPropertyChanged
    {
        private MakeObjectReactiveHelper _reactiveHelper;
        private string _name;
        private IDisposable _registration;
        
        public MainViewModel()
        {
            _reactiveHelper = new MakeObjectReactiveHelper(this);
            _registration = this.WhenAny(x => x.Name, x => !string.IsNullOrEmpty(x.Value))
                .Subscribe((b) =>
                {
                    _canDisplay = b;
                    NotifyOfPropertyChange(() => CanDisplay);
                });
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    NotifyOfPropertyChange(() => Name);                    
                }
            }
        }

        public void Display()
        {
            MessageBox.Show("You clicked on DisplayCommand: Name is " + Name);
        }
        bool _canDisplay;
        public bool CanDisplay
        {
            get 
            {
                return _canDisplay;                
            }            
        }


        #region IReactiveNotifyPropertyChanged Members

        public IObservable<IObservedChange<object, object>> Changed
        {
            get { return _reactiveHelper.Changed; }
        }

        public IObservable<IObservedChange<object, object>> Changing
        {
            get { return _reactiveHelper.Changing; }
        }

        public IDisposable SuppressChangeNotifications()
        {
            return _reactiveHelper.SuppressChangeNotifications();
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        #endregion
    }
}

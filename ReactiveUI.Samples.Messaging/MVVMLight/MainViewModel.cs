using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace ReactiveUI.Samples.Messaging.MVVMLight
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Publisher = new PublisherViewModel();
            Subscriber = new SubscriberViewModel();
        }
        public PublisherViewModel Publisher { get; set; }
        public SubscriberViewModel Subscriber { get; set; }
     
         
    }

    public class PublisherViewModel : ViewModelBase
    {
        public PublisherViewModel()
        {
            PublishCommand = new RelayCommand(() =>
            {
                Messenger.Default.Send<object>(null);
                
            });
            
        }

        public RelayCommand PublishCommand { get; protected set; }
    }

    

    public class SubscriberViewModel : ViewModelBase
    {
        public SubscriberViewModel()
        {
            Messenger.Default.Register<object>(this, _ =>
            {
                Value++;
            });

        }


        private int _value;

        public int Value
        {
            get { return _value; }
            set
            {
                if (value != _value)
                {
                    _value = value;
                    RaisePropertyChanged(() => Value);

                }
            }
        }

    }
}
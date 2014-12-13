using System;
using ReactiveUI;

namespace ReactiveUI.Samples.Messaging.RxUI
{
    public class MainViewModel : ReactiveObject
    {
        public MainViewModel()
        {
            Publisher = new PublisherViewModel();
            Subscriber = new SubscriberViewModel();
        }
        public PublisherViewModel Publisher { get; set; }
        public SubscriberViewModel Subscriber { get; set; }
         
    }

    public class PublisherViewModel : ReactiveObject
    {
        public PublisherViewModel()
        {
            PublishCommand = ReactiveCommand.Create();
            MessageBus.Current.RegisterMessageSource(PublishCommand);
        }

        public IReactiveCommand<object> PublishCommand { get; protected set; }
    }

    public class SubscriberViewModel : ReactiveObject
    {
        public SubscriberViewModel()
        {
            MessageBus.Current.Listen<object>().Subscribe(_ =>
            {
                Value++;
            });
        }


        private int _Value;

        public int Value
        {
            get { return _Value; }
            set { this.RaiseAndSetIfChanged(ref _Value, value); }
        }

    }


}
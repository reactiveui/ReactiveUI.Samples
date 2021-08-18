using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;

namespace ReactiveUI.Samples.Messaging.CaliburnMicro
{
   
        public class MainViewModel : Screen
        {
            public MainViewModel()
            {
                //usually the IoC container will take care of the creation of the EventAggregator
                IEventAggregator eventAggregator = new EventAggregator();
                Publisher = new PublisherViewModel(eventAggregator);
                Subscriber = new SubscriberViewModel(eventAggregator);
            }
            public PublisherViewModel Publisher { get; set; }
            public SubscriberViewModel Subscriber { get; set; }


        }

        public class PublisherViewModel : Screen
        {
            private readonly IEventAggregator _eventAggregator;

            public PublisherViewModel(IEventAggregator eventAggregator)
            {
                _eventAggregator = eventAggregator;
            }


            public void Publish()
            {
                _eventAggregator.PublishOnCurrentThread(new object());
            }

            
        }



        public class SubscriberViewModel : Screen,IHandle<Object>
        {
           

            public SubscriberViewModel(IEventAggregator eventAggregator)
            {
               eventAggregator.Subscribe(this);
               
            }


            private int _value;

            public int Value
            {
                get { return _value; }
                set
                {
                    if (value != _value)
                    {
                        if (value == _value) return;
                        _value = value;
                        NotifyOfPropertyChange(() => Value);
                    }
                }
            }

            public void Handle(object message)
            {
                Value++;
            }
        }
    
}

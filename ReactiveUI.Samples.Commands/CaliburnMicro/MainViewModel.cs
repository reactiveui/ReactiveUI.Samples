using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;


namespace ReactiveUI.Samples.Commands.CaliburnMicro
{
    public class MainViewModel : Screen
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    NotifyOfPropertyChange(() => Name);
                    NotifyOfPropertyChange(() => CanDisplay);                    

                }
            }
        }

        public void Display()
        {
            MessageBox.Show("You clicked on DisplayCommand: Name is " + Name);
        }
        public bool CanDisplay
        {
            get 
            {
                return !string.IsNullOrEmpty(Name);                
            }            
        }

        private int _progress;
        public int Progress
        {
            get { return _progress; }
            set
            {
                if (value != _progress)
                {
                    _progress = value;
                    NotifyOfPropertyChange(() => Progress);

                }
            }
        }


        public IEnumerable<IResult> StartAsyncWork()
        {
            Progress = 0;
            while (Progress <= 100)
            { 
                Progress += 10;
                yield return new BackgroundWork(() => Thread.Sleep(100));
               
            }
        }

        #region INotifyPropertyChanging Members

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        #endregion
    }
}

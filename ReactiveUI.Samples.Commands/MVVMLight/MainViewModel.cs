
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace ReactiveUI.Samples.Commands.MVVMLight
{
    class MainViewModel : ViewModelBase
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
                    RaisePropertyChanged(() => Name);

                    DisplayCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private RelayCommand _displayCommand;

        public RelayCommand DisplayCommand
        {
            get
            {
                return _displayCommand ?? (_displayCommand = new RelayCommand(
                                                     () => MessageBox.Show("You clicked on DisplayCommand: Name is " +
                                                                           Name),
                                                     () => !string.IsNullOrEmpty(Name)));
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
                    RaisePropertyChanged(() => Progress);

                }
            }
        }

        private void DoSomeWorK()
        {
            Progress = 0;
            Task.Factory.StartNew(() =>
            {
                while (Progress <= 100)
                {
                    
                    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        Progress+=10;    
                    }));
                    Thread.Sleep(100);
                    
                }
            });
        }

        private RelayCommand _startAsyncCommand;

        public RelayCommand StartAsyncCommand
        {
            get
            {
                return _startAsyncCommand ?? (_startAsyncCommand = new RelayCommand(
                                                     () => DoSomeWorK()));
            }
        }



    }
}
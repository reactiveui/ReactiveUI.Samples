
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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



    }
}
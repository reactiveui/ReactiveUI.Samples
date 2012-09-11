using System;
using System.Windows;
using ReactiveUI.Xaml;

namespace ReactiveUI.Samples.Commands.RxUI
{
    public class MainViewModel : ReactiveObject
    {

        public MainViewModel()
        {
            DisplayCommand = new ReactiveCommand(this.WhenAny(x => x.Name, x => !string.IsNullOrEmpty(x.Value)));
            DisplayCommand.Subscribe(_ => MessageBox.Show("You clicked on DisplayCommand: Name is " + Name));
        }
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { this.RaiseAndSetIfChanged(x => x.Name, value); }
        }

        public IReactiveCommand DisplayCommand { get; protected set; }


    }
}
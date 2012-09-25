using System;
using Caliburn.Micro;

namespace ReactiveUI.Samples.SideBySide.CaliburnMicro.ViewModels
{
    public class PersonViewModel : Screen
    {
        public class PersonModel : ReactiveValidatedObject
        {
            private int _Age;

            [ValidatesViaMethod(AllowBlanks = false, AllowNull = false, Name = "IsAgeValid",
                ErrorMessage = "Please enter a valid age 0..120")]
            public int Age
            {
                get { return _Age; }
                set { this.RaiseAndSetIfChanged(x => x.Age, value); }
            }

            public bool IsAgeValid(int age)
            {
                return ((age >= 0) && (age <= 120));
            }
        }

        public PersonViewModel()
        {
            Person = new PersonModel();
            Person.ValidationObservable.Subscribe(x => IsValid = this.Person.IsObjectValid());

        }

        public PersonModel Person { get; set; }
       

        private bool _IsValid;

        public bool IsValid
        {
            get { return _IsValid; }
            set
            {
                if (value==_IsValid) return;
                _IsValid = value;
                NotifyOfPropertyChange(() => IsValid);
            }
        }
 
    }
}
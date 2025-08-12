using System;

namespace ReactiveUI.Samples.Basics.ViewModels
{
    public class PersonViewModel : ReactiveValidatedObject
    {

        public PersonViewModel()
        {
            ValidationObservable.Subscribe(x => IsValid = this.IsObjectValid());
        }
        private int _Age;

        [ValidatesViaMethod(AllowBlanks = false, AllowNull = false, Name = "IsAgeValid", ErrorMessage = "Please enter a valid age 0..120")]
        public int Age
        {
            get { return _Age; }
            set { this.RaiseAndSetIfChanged(ref _Age, value); }
        }

        public bool IsAgeValid(int age)
        {
            return ((age >= 0) && (age <= 120));
        }

        private bool _IsValid;

        public bool IsValid
        {
            get { return _IsValid; }
            set { this.RaiseAndSetIfChanged(ref _IsValid, value); }
        }
 
    }
}

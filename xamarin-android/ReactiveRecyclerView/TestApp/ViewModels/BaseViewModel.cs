using ReactiveUI;

namespace TestApp
{
    public class BaseViewModel : ReactiveObject, ISupportsActivation
    {
        protected BaseViewModel() {
            Activator = new ViewModelActivator();
        }

        public ViewModelActivator Activator { get; }
    }
}
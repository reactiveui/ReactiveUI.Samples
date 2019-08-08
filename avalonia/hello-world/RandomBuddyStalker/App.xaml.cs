using Avalonia;
using Avalonia.Markup.Xaml;

namespace ReactiveAvalonia.RandomBuddyStalker {
    public class App : Application {
        public override void Initialize() {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace ReactiveUI.UwpRouting.Skia.Tizen
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new TizenHost(() => new ReactiveUI.UwpRouting.App(), args);
            host.Run();
        }
    }
}

using NuGet.Protocol.Core.Types;
using ReactiveUI;

namespace Packages
{
    public class NuGetViewModel : ViewModelBase
    {
        private IPackageSearchMetadata _packageSearchMetadata;

        public NuGetViewModel(IPackageSearchMetadata packageSearchMetadata)
        {
            _packageSearchMetadata = packageSearchMetadata;
        }

        public IPackageSearchMetadata PackageMetadata
        {
            get => _packageSearchMetadata;
            set => this.RaiseAndSetIfChanged(ref _packageSearchMetadata, value);
        }
    }
}

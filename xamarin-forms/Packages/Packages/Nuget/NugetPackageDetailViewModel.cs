using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using NuGet.Protocol.Core.Types;
using ReactiveUI;
using Sextant;

namespace Packages
{
    public class NuGetPackageDetailViewModel : NavigationViewModelBase
    {
        private IPackageSearchMetadata _packageSearchMetadata;
        private readonly ObservableAsPropertyHelper<IEnumerable<NuGetVersionViewModel>> _versions;

        public NuGetPackageDetailViewModel()
        {
            GetVersions = ReactiveCommand.CreateFromTask<IPackageSearchMetadata, IEnumerable<NuGetVersionViewModel>>(ExecuteGetVersions);

            _versions = GetVersions.ToProperty(this, x => x.Versions, scheduler: RxApp.MainThreadScheduler);
        }

        public ReactiveCommand<IPackageSearchMetadata, IEnumerable<NuGetVersionViewModel>> GetVersions { get; set; }

        public IPackageSearchMetadata PackageSearchMetadata
        {
            get => _packageSearchMetadata;
            set => this.RaiseAndSetIfChanged(ref _packageSearchMetadata, value);
        }

        public IEnumerable<NuGetVersionViewModel> Versions => _versions.Value;


        public override IObservable<Unit> WhenNavigatedTo(INavigationParameter parameter)
        {
            if (parameter.ContainsKey("PackageMetadata"))
            {
                parameter.TryGetValue("PackageMetadata", out var meatadata);

                PackageSearchMetadata = (IPackageSearchMetadata)meatadata;
            }

            return base.WhenNavigatedTo(parameter);
        }

        private async Task<IEnumerable<NuGetVersionViewModel>> ExecuteGetVersions(IPackageSearchMetadata packageSearchMetadata)
        {
            var versions = await packageSearchMetadata.GetVersionsAsync();
            return versions.Reverse().Take(30).Select(x => new NuGetVersionViewModel(x));
        }
    }
}

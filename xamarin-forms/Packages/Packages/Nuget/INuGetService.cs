using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NuGet.Protocol.Core.Types;

namespace Packages
{
    public interface INuGetService
    {
        Task<IEnumerable<IPackageSearchMetadata>> SearchNuGetPackages(string term, CancellationToken token);
    }
}

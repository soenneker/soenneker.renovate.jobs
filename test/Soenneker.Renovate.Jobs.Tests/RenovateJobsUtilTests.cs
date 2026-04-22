using Soenneker.Renovate.Jobs.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Renovate.Jobs.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class RenovateJobsUtilTests : HostedUnitTest
{
    private readonly IRenovateJobsUtil _util;

    public RenovateJobsUtilTests(Host host) : base(host)
    {
        _util = Resolve<IRenovateJobsUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}

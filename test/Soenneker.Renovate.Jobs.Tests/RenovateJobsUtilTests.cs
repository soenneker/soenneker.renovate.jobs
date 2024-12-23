using Soenneker.Renovate.Jobs.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Renovate.Jobs.Tests;

[Collection("Collection")]
public class RenovateJobsUtilTests : FixturedUnitTest
{
    private readonly IRenovateJobsUtil _util;

    public RenovateJobsUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IRenovateJobsUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}

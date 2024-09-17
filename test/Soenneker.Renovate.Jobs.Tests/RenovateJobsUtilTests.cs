using System.Threading.Tasks;
using FluentAssertions;
using Soenneker.Facts.Local;
using Soenneker.Renovate.Jobs.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;
using Xunit.Abstractions;

namespace Soenneker.Renovate.Jobs.Tests;

[Collection("Collection")]
public class RenovateJobsUtilTests : FixturedUnitTest
{
    private readonly IRenovateJobsUtil _util;

    public RenovateJobsUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IRenovateJobsUtil>(true);
    }

    //[ManualFact]
    [LocalFact]
    public async Task AddJob()
    {
        var jobId = await _util.AddJob("", "", "");
        jobId.Should().NotBeNull();
    }
}
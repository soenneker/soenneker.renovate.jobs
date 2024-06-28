using System.Threading.Tasks;

namespace Soenneker.Renovate.Jobs.Abstract;

/// <summary>
/// A utility library for Mend Renovate job related operations
/// </summary>
public interface IRenovateJobsUtil
{
    ValueTask<string?> AddJob(string username, string repository, string sessionCookie);
}
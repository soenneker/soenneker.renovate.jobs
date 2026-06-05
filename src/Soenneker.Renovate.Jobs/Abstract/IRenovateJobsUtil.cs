using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Renovate.Jobs.Abstract;

/// <summary>
/// A utility library for Mend Renovate job related operations
/// </summary>
public interface IRenovateJobsUtil
{
    /// <summary>
    /// Adds job.
    /// </summary>
    /// <param name="username">The username.</param>
    /// <param name="repository">The repository.</param>
    /// <param name="sessionCookie">The session cookie.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<string?> AddJob(string username, string repository, string sessionCookie, CancellationToken cancellationToken = default);
}
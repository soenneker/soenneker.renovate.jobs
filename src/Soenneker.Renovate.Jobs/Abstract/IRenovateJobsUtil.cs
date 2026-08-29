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
    /// <param name="username">Receives the decoded username when parsing succeeds.</param>
    /// <param name="repository">Repository for the add job operation.</param>
    /// <param name="sessionCookie">Session Cookie for the add job operation.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the text returned by add Job.</returns>
    ValueTask<string?> AddJob(string username, string repository, string sessionCookie, CancellationToken cancellationToken = default);
}

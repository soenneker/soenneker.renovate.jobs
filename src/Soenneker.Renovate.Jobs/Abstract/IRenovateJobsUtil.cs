using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Renovate.Jobs.Abstract;

/// <summary>
/// Starts Mend-hosted Renovate jobs for GitHub repositories.
/// </summary>
public interface IRenovateJobsUtil
{
    /// <summary>
    /// Starts a Renovate job using an authenticated Mend session.
    /// </summary>
    /// <param name="username">The GitHub owner name.</param>
    /// <param name="repository">The GitHub repository name.</param>
    /// <param name="sessionCookie">The secret Mend <c>mend_session</c> cookie value.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The Mend response body, or <c>null</c> when the request fails.</returns>
    ValueTask<string?> AddJob(string username, string repository, string sessionCookie, CancellationToken cancellationToken = default);
}

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Soenneker.Extensions.HttpContent;
using Soenneker.Extensions.Task;
using Soenneker.Extensions.ValueTask;
using Soenneker.Renovate.Client.Abstract;
using Soenneker.Renovate.Jobs.Abstract;
using MediaTypeHeaderValue = System.Net.Http.Headers.MediaTypeHeaderValue;

namespace Soenneker.Renovate.Jobs;

public sealed class RenovateJobsUtil : IRenovateJobsUtil
{
    private readonly IRenovateClient _renovateClient;
    private readonly ILogger<RenovateJobsUtil> _logger;

    private const string _mendUri = "https://developer.mend.io/api/repos/github/";

    public RenovateJobsUtil(IRenovateClient renovateClient, ILogger<RenovateJobsUtil> logger)
    {
        _renovateClient = renovateClient;
        _logger = logger;
    }

    public async ValueTask<string?> AddJob(string username, string repository, string sessionCookie, CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("Adding Renovate job ({username}/{repository})...", username, repository);

        string uri = _mendUri + Uri.EscapeDataString(username) + "/" + Uri.EscapeDataString(repository) + "/renovate/job/add";

        const string content = "{\"selectedBranches\":[]}";

        var stringContent = new StringContent(content);
        stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        stringContent.Headers.Add("X-App-Id", "1");

        stringContent.AddCookie("mend_session", sessionCookie, uri);

        using var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
        requestMessage.Content = stringContent;
        requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpClient client = await _renovateClient.Get(cancellationToken).NoSync();

        try
        {
            using HttpResponseMessage response = await client.SendAsync(requestMessage, cancellationToken).NoSync();
            string responseContent = await response.Content.ReadAsStringAsync(cancellationToken).NoSync();

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Mend returned {StatusCode} while adding Renovate job ({Username}/{Repository}): {ResponseContent}",
                    response.StatusCode, username, repository, responseContent);
                return null;
            }

            return responseContent;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Could not add Renovate job ({Username}/{Repository})", username, repository);
            return null;
        }
    }
}

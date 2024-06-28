using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Soenneker.Extensions.HttpContent;
using Soenneker.Extensions.Task;
using Soenneker.Extensions.ValueTask;
using Soenneker.Renovate.Client.Abstract;
using Soenneker.Renovate.Jobs.Abstract;
using MediaTypeHeaderValue = System.Net.Http.Headers.MediaTypeHeaderValue;

namespace Soenneker.Renovate.Jobs;

/// <inheritdoc cref="IRenovateJobsUtil"/>
public class RenovateJobsUtil : IRenovateJobsUtil
{
    private readonly IRenovateClient _renovateClient;
    private readonly ILogger<RenovateJobsUtil> _logger;

    private const string _mendUri = "https://developer.mend.io/api/repos/github/";

    public RenovateJobsUtil(IRenovateClient renovateClient, ILogger<RenovateJobsUtil> logger)
    {
        _renovateClient = renovateClient;
        _logger = logger;
    }

    public async ValueTask<string?> AddJob(string username, string repository, string sessionCookie)
    {
        string uri = _mendUri + username + "/" + repository + "/renovate/job/add";

        const string content = "{\"selectedBranches\":[]}";

        var stringContent = new StringContent(content);
        stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        stringContent.Headers.Add("X-App-Id", "1");

        stringContent.AddCookie("mend_session", sessionCookie, uri);

        var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
        requestMessage.Content = stringContent;
        requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage? response = null;
        string? responseContent = null;

        HttpClient client = await _renovateClient.Get().NoSync();

        try
        {
            response = await client.SendAsync(requestMessage).NoSync();
            response.EnsureSuccessStatusCode();
            responseContent = await response.Content.ReadAsStringAsync().NoSync();
        }
        catch (Exception e)
        {
            if (response != null)
            {
                responseContent = await response.Content.ReadAsStringAsync().NoSync();
                _logger.LogError(e, responseContent);
                return null;
            }
        }

        return responseContent;
    }
}
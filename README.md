[![](https://img.shields.io/nuget/v/soenneker.renovate.jobs.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.renovate.jobs/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.renovate.jobs/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.renovate.jobs/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.renovate.jobs.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.renovate.jobs/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.renovate.jobs/build-and-test.yml?label=build%20and%20test&style=for-the-badge)](https://github.com/soenneker/soenneker.renovate.jobs/actions/workflows/build-and-test.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.renovate.jobs/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.renovate.jobs/actions/workflows/codeql.yml)

# Soenneker.Renovate.Jobs

Starts a Mend-hosted Renovate job for a GitHub repository using an authenticated Mend session.

## Installation and registration

```bash
dotnet add package Soenneker.Renovate.Jobs
```

```csharp
using Soenneker.Renovate.Jobs.Registrars;

services.AddRenovateJobsUtilAsScoped();
```

The scoped jobs utility and client wrapper reuse a singleton cached `HttpClient`. Ending a scope does not destroy the shared client or its cookie container.

## Start a job

```csharp
using Soenneker.Renovate.Jobs.Abstract;

string? response = await renovateJobs.AddJob(
    username: "soenneker",
    repository: "example-repository",
    sessionCookie: mendSessionCookie,
    cancellationToken);

if (response is null)
{
    // The request failed; inspect application logs.
}
```

`username` and `repository` are GitHub path segments. `sessionCookie` is sent as the `mend_session` cookie to `developer.mend.io`; treat it as a secret and never persist or log it. The request selects no branch override, allowing Renovate's repository configuration to determine branch behavior.

The returned string is Mend's response body. HTTP and transport failures are logged and return `null`; this package does not deserialize the response into a stable DTO.

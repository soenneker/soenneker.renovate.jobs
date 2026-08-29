[![](https://img.shields.io/nuget/v/soenneker.renovate.jobs.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.renovate.jobs/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.renovate.jobs/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.renovate.jobs/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.renovate.jobs.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.renovate.jobs/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.renovate.jobs/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.renovate.jobs/actions/workflows/codeql.yml)

# Soenneker.Renovate.Jobs

A utility library for Mend Renovate job related operations.

## Install

```bash
dotnet add package Soenneker.Renovate.Jobs
```

## Quick start

```csharp
using Soenneker.Renovate.Jobs.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddRenovateJobsUtilAsSingleton();
```

Adds `IRenovateJobsUtil` as a singleton service.

## What you get

- `IRenovateJobsUtil` — A utility library for Mend Renovate job related operations.
- `RenovateJobsUtilRegistrar` — A utility library for Mend Renovate job related operations.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `RenovateJobsUtilRegistrar.AddRenovateJobsUtilAsSingleton(services)` | Adds `IRenovateJobsUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `RenovateJobsUtilRegistrar.AddRenovateJobsUtilAsScoped(services)` | Adds `IRenovateJobsUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

# Judj0 DotNet

Client for Judj0 API written in .NET Core.

## Features
 - Authentication
 - Authorization
 - Submissions
 - Statuses and Languages 
 - System and Configuration
 - Statistics
 - Health Check
 - Information

## Installation
```bash
dotnet add package Judj0.DotNet
```

## Usage

### Configuration
Add in cofiguration Judje0 Section with the following parameters:
```json
    "Judje0": {
        "BaseUrl": "", // Base URL of the Judj0 API
        "AuthorizationHeader": "X-Auth-Token", // Header for the Authorization Token
        "AuthorizationToken": "", // Token for the Authorization
        "AuthenticationHeader": "X-Auth-User", // Header for the Authentication Token
        "AuthenticationToken": "" // Token for the Authentication
    }
```

Register the Judj0 Dotnet dependency like this:

```csharp
using Judj0.DotNet;

builder.Services.AddJudj0Client(Configuration);
```

### Authentication

Resolve with dependency injection the `IAuthenticationService` and use the `AuthenticateAsync` method to Authenticate.

```csharp

using Judj0.DotNet;

public class AuthenticationExample
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationExample(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public async Task Authenticate()
    {
        var response = await _authenticationService.AuthenticateAsync();
    }
}
```

### Authorization
Resolve with dependency injection the `IAuthorizationService` and use the `AuthorizeAsync` method to Authorize.
    
```csharp
public class AuthorizationExample
{
    private readonly IAuthorizationService _authorizationService;

    public AuthorizationExample(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }

    public async Task Authenticate()
    {
        var response = await _authorizationService.AuthorizeAsync();
    }
}
```

### Submissions
Resolve with dependency injection the `ISubmissionService`

#### Create a Submission

Use the `CreateAsync` method to create a Submissions.

```csharp
public class SubmissionExample
{
    private readonly ISubmissionService _submissionService;

    public SubmissionExample(ISubmissionService submissionService)
    {
        _submissionService = submissionService;
    }

    public async Task CreateSubmission()
    {
        var submission = new Submission(
            "#include <stdio.h>\n\nint main(void) {\n  char name[10];\n  scanf(\"%s\", name);\n  printf(\"hello, %s\n\", name);\n  return 0;\n}",
            50)
        {
            Stdin = "world"
        };
        
        var response = await _submissionService.CreateAsync(submission);
    }
}
```

#### Get a Submission

Use the `GetAsync` method to create a Submissions.

```csharp
public class SubmissionExample
{
    private readonly ISubmissionService _submissionService;

    public SubmissionExample(ISubmissionService submissionService)
    {
        _submissionService = submissionService;
    }

    public async Task GetSubmission()
    {
        var response = await _submissionService.GetAsync("b16fcd66-79c3-4ba5-986d-8fc85ea24f04");
    }
}
```

Documentation in progress
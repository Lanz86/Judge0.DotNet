using Judge0.DotNet.Consts;
using Judge0.DotNet.Options;
using Judge0.DotNet.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Judge0.DotNet;

public static class DependencyInjection
{
    public static void AddJudge0Dotnet(this IServiceCollection serviceProvider, IConfiguration configuration)
    {
        var judje0Options = configuration.GetSection(Judje0Options.JudjeO)
            .Get<Judje0Options>() ?? throw new ArgumentNullException(nameof(Judje0Options));

        serviceProvider.AddHttpClient(CommonConsts.JUDJE0_HTTP_CLIENT_NAME, client =>
        {
            client.BaseAddress = new Uri(judje0Options.BaseUrl);
            client.DefaultRequestHeaders.Add(judje0Options.AuthenticationHeader, judje0Options.AuthenticationToken);
            client.DefaultRequestHeaders.Add(judje0Options.AuthorizationHeader, judje0Options.AuthorizationToken);
        });
        
        serviceProvider.AddTransient<IAuthenticationService, AuthenticationService>();
        serviceProvider.AddTransient<IAuthorizationService, AuthorizationService>();
        serviceProvider.AddTransient<IConfigurationService, ConfigurationService>();
        serviceProvider.AddTransient<IHealthCheckService, HealthCheckService>();
        serviceProvider.AddTransient<IInformationService, InformationService>();
        serviceProvider.AddTransient<ILanguageService, LanguageService>();
        serviceProvider.AddTransient<IStatisticsService, StatisticsService>();
        serviceProvider.AddTransient<IStatusService, StatusService>();
        serviceProvider.AddTransient<ISubmissionService, SubmissionService>();
        serviceProvider.AddTransient<ISystemService, SystemService>();
    }
}

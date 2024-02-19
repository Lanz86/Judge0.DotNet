using Judge0.DotNet;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace judge0sdk_library_tests;

public class ServiceCollectionExtensions
{
    public static IServiceProvider GetServiceProvider() 
    {
        var service = new ServiceCollection();
        
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        
        service.AddJudge0Dotnet(configuration);
        return service.BuildServiceProvider();
    }
    
    public static IServiceProvider GetUnauthorizedServiceProvider() 
    {
        var service = new ServiceCollection();
        
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.Unauthorized.json")
            .Build();
        
        service.AddJudge0Dotnet(configuration);
        return service.BuildServiceProvider();
    }
    
    public static IServiceProvider GetForbiddenServiceProvider() 
    {
        var service = new ServiceCollection();
        
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.Forbidden.json")
            .Build();
        
        service.AddJudge0Dotnet(configuration);
        return service.BuildServiceProvider();
    }
    
}
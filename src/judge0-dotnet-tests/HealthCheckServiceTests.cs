using Judge0.DotNet;
using Microsoft.Extensions.DependencyInjection;

namespace judge0sdk_library_tests;

public class HealthCheckServiceTests
{
    private IServiceProvider serviceProvider;
    [SetUp]
    public void Setup()
    {
        serviceProvider = ServiceCollectionExtensions.GetServiceProvider();
    }
    
    [Test]
    public async Task Should_Return_HealthCheck_When_GetAsync_Is_Called()
    {
        var healthCheckService = serviceProvider.GetRequiredService<IHealthCheckService>();
        var result = await healthCheckService.GetWorkersyAsync(CancellationToken.None);
        
        Assert.IsNotNull(result);
    }
}
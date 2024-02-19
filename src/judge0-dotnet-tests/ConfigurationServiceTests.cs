using Judge0.DotNet;
using Microsoft.Extensions.DependencyInjection;

namespace judge0sdk_library_tests;

public class ConfigurationServiceTests
{
    private IServiceProvider serviceProvider;
    [SetUp]
    public void Setup()
    {
        serviceProvider = ServiceCollectionExtensions.GetServiceProvider();
    }
    
    [Test]
    public async Task Should_Return_Configuration_When_GetConfigInfoAsync_Is_Called()
    {
        var configurationService = serviceProvider.GetRequiredService<IConfigurationService>();
        var result = await configurationService.GetConfigInfoAsync(CancellationToken.None);
        
        Assert.IsNotNull(result);
    }
}
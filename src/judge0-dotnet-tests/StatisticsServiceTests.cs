using Judge0.DotNet;
using Microsoft.Extensions.DependencyInjection;

namespace judge0sdk_library_tests;

public class StatisticsServiceTests
{
    private IServiceProvider serviceProvider;
    [SetUp]
    public void Setup()
    {
        serviceProvider = ServiceCollectionExtensions.GetServiceProvider();
    }
    
    [Test]
    public async Task Should_Return_Statistics_When_GetAsync_Is_Called()
    {
        var statisticsService = serviceProvider.GetRequiredService<IStatisticsService>();
        var result = await statisticsService.GetAsync();
        
        Assert.IsNotNull(result);
    }
}
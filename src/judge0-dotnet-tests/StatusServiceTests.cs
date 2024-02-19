using Judge0.DotNet;
using Microsoft.Extensions.DependencyInjection;

namespace judge0sdk_library_tests;

public class StatusServiceTests
{
    private IServiceProvider serviceProvider;
    [SetUp]
    public void Setup()
    {
        serviceProvider = ServiceCollectionExtensions.GetServiceProvider();
    }
    
    [Test]
    public async Task Should_Return_Statuses_When_GetAsync_Is_Called()
    {
        var statusService = serviceProvider.GetRequiredService<IStatusService>();
        var result = await statusService.GetAsync(CancellationToken.None);
        
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Any());
    }
   
}
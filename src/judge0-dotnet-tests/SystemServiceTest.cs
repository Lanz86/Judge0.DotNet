using Judge0.DotNet;
using Microsoft.Extensions.DependencyInjection;

namespace judge0sdk_library_tests;

public class SystemServiceTest
{
    private IServiceProvider serviceProvider;
    [SetUp]
    public void Setup()
    {
        serviceProvider = ServiceCollectionExtensions.GetServiceProvider();
    }
    
    [Test]
    public async Task Should_Return_SystemInfo_When_GetSystemInfoAsync_Is_Called()
    {
        var systemService = serviceProvider.GetRequiredService<ISystemService>();
        var result = await systemService.GetSystemInfoAsync(CancellationToken.None);
        
        Assert.IsNotNull(result);
    }
}
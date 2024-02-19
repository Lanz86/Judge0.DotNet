using Judge0.DotNet;
using Microsoft.Extensions.DependencyInjection;

namespace judge0sdk_library_tests;

public class InformationServiceTests
{
    private IServiceProvider serviceProvider;
    [SetUp]
    public void Setup()
    {
        serviceProvider = ServiceCollectionExtensions.GetServiceProvider();
    }
    
    [Test]
    public async Task Should_Return_About_When_GetAboutAsync_Is_Called()
    {
        var informationService = serviceProvider.GetRequiredService<IInformationService>();
        var result = await informationService.GetAboutAsync();
        
        Assert.IsNotNull(result);
    }
    
    [Test]
    public async Task Should_Return_Version_When_GetVersionAsync_Is_Called()
    {
        var informationService = serviceProvider.GetRequiredService<IInformationService>();
        var result = await informationService.GetVersionAsync();
        
        Assert.IsNotNull(result);
    }
    
    [Test]
    public async Task Should_Return_Isolate_When_GetIsolateAsync_Is_Called()
    {
        var informationService = serviceProvider.GetRequiredService<IInformationService>();
        var result = await informationService.GetIsolateAsync();
        
        Assert.IsNotNull(result);
    }
    
    [Test]
    public async Task Should_Return_License_When_GetLicenseAsync_Is_Called()
    {
        var informationService = serviceProvider.GetRequiredService<IInformationService>();
        var result = await informationService.GetLicenseAsync();
        
        Assert.IsNotNull(result);
    }
    
}
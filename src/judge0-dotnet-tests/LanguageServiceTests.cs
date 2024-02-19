using Judge0.DotNet;
using Judge0.DotNet.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace judge0sdk_library_tests;

public class LanguageServiceTests
{
    private IServiceProvider serviceProvider;
    [SetUp]
    public void Setup()
    {
        serviceProvider = ServiceCollectionExtensions.GetServiceProvider();
    }
    
    [Test]
    public async Task Should_Return_Languages_When_GetAsync_Is_Called()
    {
        var languageService = serviceProvider.GetRequiredService<ILanguageService>();
        var result = await languageService.GetAsync(CancellationToken.None);
        
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Any());
    }
    
    [Test]
    public async Task Should_Return_Language_When_GetAsync_Is_Called()
    {
        var languageService = serviceProvider.GetRequiredService<ILanguageService>();
        var result = await languageService.GetAsync(51, CancellationToken.None);
        
        Assert.IsNotNull(result);
    }
    
    [Test]
    public async Task Should_Throw_NotFoundException_When_GetAsync_Is_Called()
    {
        var languageService = serviceProvider.GetRequiredService<ILanguageService>();
        var exception = Assert.ThrowsAsync<NotFoundException>(() => languageService.GetAsync(-10, CancellationToken.None));
        
        Assert.IsNotNull(exception);
    }
    
    [Test]
    public async Task Should_Get_All_Languages_When_GetAllAsync_Is_Called()
    {
        var languageService = serviceProvider.GetRequiredService<ILanguageService>();
        var result = await languageService.GetAllAsync(CancellationToken.None);
        
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Any());
    }
}
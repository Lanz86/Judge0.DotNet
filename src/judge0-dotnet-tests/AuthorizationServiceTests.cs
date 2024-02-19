using Judge0.DotNet;
using Judge0.DotNet.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace judge0sdk_library_tests;

public class AuthorizationServiceTests
{
    
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public async Task Shoud_Return_True_When_AuthorizeAsync_Is_Called()
    {
        var serviceProvider = ServiceCollectionExtensions.GetServiceProvider();
        var authorizationService = serviceProvider.GetRequiredService<IAuthorizationService>();
        var result = await authorizationService.AuthorizeAsync();
        
        Assert.IsTrue(result);
    }
    
    [Test]
    public async Task Shoud_Throw_ForbiddenException_When_AuthorizeAsync_Is_Called()
    {
        var serviceProvider = ServiceCollectionExtensions.GetForbiddenServiceProvider();
        var authorizationService = serviceProvider.GetRequiredService<IAuthorizationService>();
        
        var exception = Assert.ThrowsAsync<ForbiddenException>(() => authorizationService.AuthorizeAsync());
        Assert.IsNotNull(exception);
    }
}
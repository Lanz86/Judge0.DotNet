using Judge0.DotNet;
using Judge0.DotNet.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace judge0sdk_library_tests;

public class AuthenticateServiceTests
{
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public async Task Shoud_Return_AuthenticateResponse_With_Token_When_AuthenticateAsync_Is_Called()
    {
        var serviceProvider = ServiceCollectionExtensions.GetServiceProvider();
        var authenticationService = serviceProvider.GetRequiredService<IAuthenticationService>();
        var result = await authenticationService.AuthenticateAsync();
        
        Assert.IsTrue(result);
    }
    
    [Test]
    public async Task Shoud_Throw_UnauthorizedException_With_Token_When_AuthenticateAsync_Is_Called()
    {
        var serviceProvider = ServiceCollectionExtensions.GetUnauthorizedServiceProvider();
        var authenticationService = serviceProvider.GetRequiredService<IAuthenticationService>();
        
        var exception = Assert.ThrowsAsync<UnauthorizedException>(() => authenticationService.AuthenticateAsync());
        Assert.IsNotNull(exception);
    }
}
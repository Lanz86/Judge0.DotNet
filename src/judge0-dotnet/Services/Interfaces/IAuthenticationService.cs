namespace Judge0.DotNet;
public interface IAuthenticationService
{
    /// <summary>
    /// With this API call you can check if your authorization token is valid. If authentication is enabled you should also authenticate in this API call.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> AuthenticateAsync(CancellationToken cancellationToken = default);
}
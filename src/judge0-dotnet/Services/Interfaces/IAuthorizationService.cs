namespace Judge0.DotNet;

public interface IAuthorizationService
{
    /// <summary>
    /// Check if your authentication token is valid.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> AuthorizeAsync(CancellationToken cancellationToken = default);
}
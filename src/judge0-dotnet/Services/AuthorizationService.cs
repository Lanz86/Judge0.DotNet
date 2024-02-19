using Judge0.DotNet.Consts;
using Judge0.DotNet.Extensions;
using Judge0.DotNet.Models;

namespace Judge0.DotNet.Services;

internal class AuthorizationService(IHttpClientFactory httpClientFactory) : IAuthorizationService
{
    private const string rootPath = "/authorize";
    /// <summary>
    /// Check if your authentication token is valid.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> AuthorizeAsync(CancellationToken cancellationToken = default)
    {
        using HttpClient httpClient = httpClientFactory.CreateClient(CommonConsts.JUDJE0_HTTP_CLIENT_NAME);
        var response = await httpClient.PostAsJsonAsync<object>(rootPath, new object(), null, cancellationToken).ConfigureAwait(false);
        return await response.BuildResponseResult<object>(cancellationToken) != null;
    }
}
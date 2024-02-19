using Judge0.DotNet.Consts;
using Judge0.DotNet.Models;
using Judge0.DotNet.Models.Systems;

namespace Judge0.DotNet.Services;

internal class SystemService(IHttpClientFactory httpClientFactory) : ISystemService
{
    private const string rootPath = "/system_info";
    
    public async Task<SystemInfo?> GetSystemInfoAsync(CancellationToken cancellationToken = default)
    {
        var httpClient = httpClientFactory.CreateClient(CommonConsts.JUDJE0_HTTP_CLIENT_NAME);
        var response = await httpClient.GetAsync(rootPath, cancellationToken).ConfigureAwait(false);
        var result = await response.BuildResponseResult<SystemInfo>(cancellationToken).ConfigureAwait(false);
        return result;
    }
    
}
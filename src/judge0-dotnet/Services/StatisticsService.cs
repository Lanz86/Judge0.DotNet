using Judge0.DotNet.Consts;
using Judge0.DotNet.Models;

namespace Judge0.DotNet.Services;

internal class StatisticsService(IHttpClientFactory httpClientFactory) : IStatisticsService
{
    private const string rootPath = "/statistics";
    
    /// <summary>
    /// Get some statistics from current instance. Result is cached for 10 minutes.
    /// </summary>
    /// <param name="invalidateCache"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<dynamic?> GetAsync(bool invalidateCache = false, CancellationToken cancellationToken = default)
    {
        var httpClient = httpClientFactory.CreateClient(CommonConsts.JUDJE0_HTTP_CLIENT_NAME);
        var response = await httpClient.GetAsync( $"{rootPath}?invalidate_cache={invalidateCache.ToString().ToLowerInvariant()}", cancellationToken).ConfigureAwait(false);
        var result = await response.BuildResponseResult<dynamic>(cancellationToken).ConfigureAwait(false);
        return result;
    }
}
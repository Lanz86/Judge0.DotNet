using Judge0.DotNet.Consts;
using Judge0.DotNet.Models;
using Judge0.DotNet.Models.Statues;

namespace Judge0.DotNet.Services;

internal class StatusService(IHttpClientFactory httpClientFactory) : IStatusService
{
    private const string rootPath = "/statuses";
    
    /// <summary>
    /// Get list of statues
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns> 
    public async Task<IEnumerable<Status>> GetAsync(CancellationToken cancellationToken = default)
    {
        var httpClient = httpClientFactory.CreateClient(CommonConsts.JUDJE0_HTTP_CLIENT_NAME);
        var response = await httpClient.GetAsync(rootPath, cancellationToken).ConfigureAwait(false);
        var result = await response.BuildResponseResult<List<Status>>(cancellationToken).ConfigureAwait(false);
        return result??Enumerable.Empty<Status>();
    }
}
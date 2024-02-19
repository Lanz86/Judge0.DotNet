using Judge0.DotNet.Consts;
using Judge0.DotNet.Models;
using Judge0.DotNet.Models.HealthChecks;

namespace Judge0.DotNet.Services;

internal class HealthCheckService(IHttpClientFactory httpClientFactory) : IHealthCheckService {
    private const string rootPath = "/workers";
    
    /// <summary>
    /// For each queue you will get:
    ///queue name
    ///queue size, i.e. number of submissions that are currently waiting to be processed
    ///available number of workers
    ///how many workers are idle
    ///how many workers are currently working
    ///  how many workers are paused
    ///how many jobs failed
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Worker>> GetWorkersyAsync(CancellationToken cancellationToken = default)
    {
        var httpClient = httpClientFactory.CreateClient(CommonConsts.JUDJE0_HTTP_CLIENT_NAME);
        var response = await httpClient.GetAsync(rootPath, cancellationToken).ConfigureAwait(false);
        
        var result = await response.BuildResponseResult<List<Worker>>(cancellationToken).ConfigureAwait(false);

        return result??Enumerable.Empty<Worker>();
    }
    
}
    
using Judge0.DotNet.Consts;
using Judge0.DotNet.Models;
using Judge0.DotNet.Models.Configurations;

namespace Judge0.DotNet.Services;

internal class ConfigurationService(IHttpClientFactory httpClientFactory) : IConfigurationService
{
    private const string rootPath = "/config_info";
    
    /// <summary>
    /// Configuration information gives you detailed information about configuration of Judge0. This configuration can be changed through judge0.conf file by admin who hosts Judge0 instance.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ConfigurationInfo?> GetConfigInfoAsync(CancellationToken cancellationToken = default)
    {
        var httpClient = httpClientFactory.CreateClient(CommonConsts.JUDJE0_HTTP_CLIENT_NAME);
        var response = await httpClient.GetAsync(rootPath, cancellationToken).ConfigureAwait(false);
        var result = await response.BuildResponseResult<ConfigurationInfo>(cancellationToken).ConfigureAwait(false);
        return result;
    }   
}
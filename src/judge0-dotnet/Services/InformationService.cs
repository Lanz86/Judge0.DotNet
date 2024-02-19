using Judge0.DotNet.Consts;
using Judge0.DotNet.Models;
using Judge0.DotNet.Models.Information;

namespace Judge0.DotNet.Services;

internal class InformationService(IHttpClientFactory httpClientFactory) : IInformationService
{
    /// <summary>
    /// Returns general information.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<About?> GetAboutAsync(CancellationToken cancellationToken = default)
    {
        var httpClient = httpClientFactory.CreateClient(CommonConsts.JUDJE0_HTTP_CLIENT_NAME);
        var response = await httpClient.GetAsync("/about", cancellationToken).ConfigureAwait(false);
        var result = await response.BuildResponseResult<About>(cancellationToken).ConfigureAwait(false);

        return result;
    }

    /// <summary>
    /// Returns current version.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<string> GetVersionAsync(CancellationToken cancellationToken = default)
    {
        var httpClient = httpClientFactory.CreateClient(CommonConsts.JUDJE0_HTTP_CLIENT_NAME);
        var response = await httpClient.GetAsync("/version", cancellationToken).ConfigureAwait(false);
        return (await response?.Content?.ReadAsStringAsync())??string.Empty;
    }
    
    /// <summary>
    /// Returns result of isolate --version.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<string> GetIsolateAsync(CancellationToken cancellationToken = default)
    {
        var httpClient = httpClientFactory.CreateClient(CommonConsts.JUDJE0_HTTP_CLIENT_NAME);
        var response = await httpClient.GetAsync("/isolate", cancellationToken).ConfigureAwait(false);
        return (await response?.Content?.ReadAsStringAsync())??string.Empty;
    }
    
    /// <summary>
    /// Returns a license.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<string> GetLicenseAsync(CancellationToken cancellationToken = default)
    {
        var httpClient = httpClientFactory.CreateClient(CommonConsts.JUDJE0_HTTP_CLIENT_NAME);
        var response = await httpClient.GetAsync("/license", cancellationToken).ConfigureAwait(false);
        return (await response?.Content?.ReadAsStringAsync())??string.Empty;
    }
}
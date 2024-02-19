using Judge0.DotNet.Consts;
using Judge0.DotNet.Models;
using Judge0.DotNet.Models.Languages;

namespace Judge0.DotNet.Services;

internal class LanguageService(IHttpClientFactory httpClientFactory) : ILanguageService
{
    private const string rootPath = "/languages";

    /// <summary>
    /// Get active languages.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Language>> GetAsync(CancellationToken cancellationToken= default)
    {
        var httpClient = httpClientFactory.CreateClient(CommonConsts.JUDJE0_HTTP_CLIENT_NAME);
        var response = await httpClient.GetAsync(rootPath, cancellationToken).ConfigureAwait(false);
        var result = await response.BuildResponseResult<List<Language>>(cancellationToken).ConfigureAwait(false);
        return result??Enumerable.Empty<Language>();
    }
    
    /// <summary>
    /// Get single language.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Language?> GetAsync(int id, CancellationToken cancellationToken)
    {
        var httpClient = httpClientFactory.CreateClient(CommonConsts.JUDJE0_HTTP_CLIENT_NAME);
        var response = await httpClient.GetAsync($"{rootPath}/{id}", cancellationToken).ConfigureAwait(false);
        var result = await response.BuildResponseResult<Language>(cancellationToken).ConfigureAwait(false);
        return result;
    }
    
    /// <summary>
    /// Get active and archived languages.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Language>> GetAllAsync(CancellationToken cancellationToken)
    {
        var httpClient = httpClientFactory.CreateClient(CommonConsts.JUDJE0_HTTP_CLIENT_NAME);
        var response = await httpClient.GetAsync( $"{rootPath}/all", cancellationToken).ConfigureAwait(false);
        var result = await response.BuildResponseResult<List<Language>>(cancellationToken).ConfigureAwait(false);
        return result??Enumerable.Empty<Language>();
    }
    
}
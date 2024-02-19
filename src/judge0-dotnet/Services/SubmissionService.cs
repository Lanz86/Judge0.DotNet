using Judge0.DotNet.Consts;
using Judge0.DotNet.Extensions;
using Judge0.DotNet.Models;
using Judge0.DotNet.Models.Submissions;

namespace Judge0.DotNet.Services;
internal class SubmissionService(IHttpClientFactory httpClientFactory) : ISubmissionService
{

    const string rootPath = "/submissions";

    /// <summary>
    /// Creates new submission. Created submission waits in queue to be processed. On successful creation, you are returned submission token which can be used to check submission status.
    /// </summary>
    /// <param name="submission"></param>
    /// <param name="base64Encoded"></param>
    /// <param name="wait"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<SubmissionResponse> CreateAsync(Submission submission, bool base64Encoded = false, bool wait = false,  CancellationToken cancellationToken = default) 
    {
        if(base64Encoded) await submission.ToBase64Async();
        using HttpClient httpClient = httpClientFactory.CreateClient(CommonConsts.JUDJE0_HTTP_CLIENT_NAME);
        var response = await httpClient.PostAsJsonAsync($"{rootPath}/?base64_encoded={base64Encoded.ToString().ToLowerInvariant()}&wait={wait.ToString().ToLowerInvariant()}", submission, cancellationToken: cancellationToken).ConfigureAwait(false);
        var result = await response.BuildResponseResult<SubmissionResponse>(cancellationToken: cancellationToken).ConfigureAwait(false);

        return result;
    }
    
    /// <summary>
    /// Returns details about submission.
    /// </summary>
    /// <param name="token"></param>
    /// <param name="base64Encoded"></param>
    /// <param name="fields"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<SubmissionResponse> GetAsync(string token, bool base64Encoded = false, string? fields = null, CancellationToken cancellationToken = default) 
    {
        var path = $"{rootPath}/{token}?base64_encoded={base64Encoded.ToString().ToLowerInvariant()}";
        if(!string.IsNullOrWhiteSpace(fields)) path += $"&fields={fields}";
        using HttpClient httpClient = httpClientFactory.CreateClient(CommonConsts.JUDJE0_HTTP_CLIENT_NAME);
        var response = await httpClient.GetAsync($"{path}", cancellationToken).ConfigureAwait(false);
        var result = await response.BuildResponseResult<SubmissionResponse>(cancellationToken: cancellationToken).ConfigureAwait(false);

        if (base64Encoded) await result.FromBase64();
        
        return result;
    }

    public async Task<SubmissionsResponse> GetAsync(bool base64Encoded = false, int page = 1,
        int perPage = 20, string? fields = null, CancellationToken cancellationToken = default)
    {
        var path = $"{rootPath}/?base64_encoded={base64Encoded.ToString().ToLowerInvariant()}&page={page}&per_page={perPage}";
        if(!string.IsNullOrWhiteSpace(fields)) path += $"&fields={fields}";
        using HttpClient httpClient = httpClientFactory.CreateClient(CommonConsts.JUDJE0_HTTP_CLIENT_NAME);
        var response = await httpClient.GetAsync($"{path}", cancellationToken).ConfigureAwait(false);
        var result = await response.BuildResponseResult<SubmissionsResponse>(cancellationToken: cancellationToken).ConfigureAwait(false);

        if (base64Encoded)
        {
            result?.Submissions.ForEach(x => { x.FromBase64(); });
        }
        
        return result??new();
    }
    
    /// <summary>
    /// Delete specific submission.
    /// </summary>
    /// <param name="token"></param>
    /// <param name="cancellationToken"></param>
    public async Task<SubmissionResponse> DeleteAysnc(string token, string? fields = null, CancellationToken cancellationToken = default)
    {
        var path = $"{rootPath}/{token}";
        if(!string.IsNullOrWhiteSpace(fields)) path += $"?fields={fields}";
        using HttpClient httpClient = httpClientFactory.CreateClient(CommonConsts.JUDJE0_HTTP_CLIENT_NAME);
        var response = await httpClient.DeleteAsync($"{rootPath}/{token}", cancellationToken).ConfigureAwait(false);
        var result = await response.BuildResponseResult<SubmissionResponse>(cancellationToken: cancellationToken).ConfigureAwait(false);
        return result ?? new();
    }

    /// <summary>
    /// Create multiple submissions at once.
    /// </summary>
    /// <param name="submissionBatch"></param>
    /// <param name="base64Encoded">
    /// boolean (optional) Default: false
    /// Set to true if you are sending Base64 encoded data.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<SubmissionResponse>> CreateBatchAsync(SubmissionBatch submissionBatch,
        bool base64Encoded = false, CancellationToken cancellationToken = default)
    {
        var path = $"{rootPath}/batch?base64_encoded={base64Encoded.ToString().ToLowerInvariant()}";
        using HttpClient httpClient = httpClientFactory.CreateClient(CommonConsts.JUDJE0_HTTP_CLIENT_NAME);
        var response = await httpClient.PostAsJsonAsync(path, submissionBatch, cancellationToken: cancellationToken).ConfigureAwait(false);
        var result = await  response.BuildResponseResult<List<SubmissionResponse>>(cancellationToken: cancellationToken).ConfigureAwait(false);
        
        return result ?? new();
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="base64Encoded"></param>
    /// <param name="page"></param>
    /// <param name="perPage"></param>
    /// <param name="fields"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<SubmissionsResponse> GetBatchAsync(string[] tokens, bool base64Encoded = false, string? fields = null, CancellationToken cancellationToken = default)
    {
        var path = $"{rootPath}/?tokens={string.Join(",", tokens)}&base64_encoded={base64Encoded.ToString().ToLowerInvariant()}";
        if(!string.IsNullOrWhiteSpace(fields)) path += $"&fields={fields}";
        using HttpClient httpClient = httpClientFactory.CreateClient(CommonConsts.JUDJE0_HTTP_CLIENT_NAME);
        var response = await httpClient.GetAsync($"{path}", cancellationToken).ConfigureAwait(false);
        var result = await response.BuildResponseResult<SubmissionsResponse>(cancellationToken: cancellationToken).ConfigureAwait(false);

        if (base64Encoded)
        {
            result?.Submissions.ForEach(x => { x.FromBase64(); });
        }
        
        return result??new();
    }
}


using Judge0.DotNet.Models.Submissions;

namespace Judge0.DotNet;

public interface ISubmissionService
{
    /// <summary>
    /// Creates new submission. Created submission waits in queue to be processed. On successful creation, you are returned submission token which can be used to check submission status.
    /// </summary>
    /// <param name="submission"></param>
    /// <param name="base64Encoded"></param>
    /// <param name="wait"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SubmissionResponse> CreateAsync(Submission submission, bool base64Encoded = false, bool wait = false,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns details about submission.
    /// </summary>
    /// <param name="token"></param>
    /// <param name="base64Encoded"></param>
    /// <param name="fields"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SubmissionResponse> GetAsync(string token, bool base64Encoded = false, string? fields = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns details about submission. Paged
    /// </summary>
    /// <param name="base64Encoded"></param>
    /// <param name="page"></param>
    /// <param name="perPage"></param>
    /// <param name="fields"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SubmissionsResponse> GetAsync(bool base64Encoded = false, int page = 1,
        int perPage = 20, string? fields = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete specific submission.
    /// </summary>
    /// <param name="token"></param>
    /// <param name="cancellationToken"></param>
    Task<SubmissionResponse> DeleteAysnc(string token, string? fields = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create multiple submissions at once.
    /// </summary>
    /// <param name="submissionBatch"></param>
    /// <param name="base64Encoded">
    /// boolean (optional) Default: false
    /// Set to true if you are sending Base64 encoded data.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<SubmissionResponse>> CreateBatchAsync(SubmissionBatch submissionBatch,
        bool base64Encoded = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="base64Encoded"></param>
    /// <param name="page"></param>
    /// <param name="perPage"></param>
    /// <param name="fields"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SubmissionsResponse> GetBatchAsync(string[] tokens, bool base64Encoded = false, string? fields = null,
        CancellationToken cancellationToken = default);
}


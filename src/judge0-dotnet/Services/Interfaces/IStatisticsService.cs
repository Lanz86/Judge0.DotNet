namespace Judge0.DotNet;

public interface IStatisticsService
{
    /// <summary>
    /// Get some statistics from current instance. Result is cached for 10 minutes.
    /// </summary>
    /// <param name="invalidateCache"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<dynamic?> GetAsync(bool invalidateCache = false, CancellationToken cancellationToken = default);
}
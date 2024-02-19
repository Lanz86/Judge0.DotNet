using Judge0.DotNet.Models.HealthChecks;

namespace Judge0.DotNet;

public interface IHealthCheckService
{
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
    Task<IEnumerable<Worker>> GetWorkersyAsync(CancellationToken cancellationToken = default);
}
    
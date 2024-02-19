using Judge0.DotNet.Models.Statues;

namespace Judge0.DotNet;

public interface IStatusService
{
    /// <summary>
    /// Get list of statues
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns> 
    Task<IEnumerable<Status>> GetAsync(CancellationToken cancellationToken = default);
}
using Judge0.DotNet.Models.Systems;

namespace Judge0.DotNet;

public interface ISystemService
{
    Task<SystemInfo?> GetSystemInfoAsync(CancellationToken cancellationToken = default);
}
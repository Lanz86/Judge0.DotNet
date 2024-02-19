using Judge0.DotNet.Models.Configurations;

namespace Judge0.DotNet;

public interface IConfigurationService
{
    /// <summary>
    /// Configuration information gives you detailed information about configuration of Judge0. This configuration can be changed through judge0.conf file by admin who hosts Judge0 instance.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ConfigurationInfo?> GetConfigInfoAsync(CancellationToken cancellationToken = default);
}
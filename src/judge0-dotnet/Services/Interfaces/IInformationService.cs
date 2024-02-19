using Judge0.DotNet.Models.Information;

namespace Judge0.DotNet;

public interface IInformationService
{
    /// <summary>
    /// Returns general information.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<About?> GetAboutAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns current version.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<string> GetVersionAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns result of isolate --version.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<string> GetIsolateAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns a license.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<string> GetLicenseAsync(CancellationToken cancellationToken = default);
}
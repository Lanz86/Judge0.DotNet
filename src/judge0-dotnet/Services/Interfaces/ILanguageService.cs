using Judge0.DotNet.Models.Languages;

namespace Judge0.DotNet;

public interface ILanguageService
{
    /// <summary>
    /// Get active languages.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<Language>> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get single language.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Language?> GetAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Get active and archived languages.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<Language>> GetAllAsync(CancellationToken cancellationToken);
}
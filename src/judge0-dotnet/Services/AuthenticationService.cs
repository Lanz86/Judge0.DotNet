using Judge0.DotNet.Consts;
using Judge0.DotNet.Extensions;
using Judge0.DotNet.Models;

namespace Judge0.DotNet.Services;

internal class AuthenticationService(IHttpClientFactory httpClientFactory) : IAuthenticationService
{
   private const string rootPath = "/authenticate";
   
   /// <summary>
   /// With this API call you can check if your authorization token is valid. If authentication is enabled you should also authenticate in this API call.
   /// </summary>
   /// <param name="cancellationToken"></param>
   /// <returns></returns>
   public async Task<bool> AuthenticateAsync(CancellationToken cancellationToken = default)
   {
      using HttpClient httpClient = httpClientFactory.CreateClient(CommonConsts.JUDJE0_HTTP_CLIENT_NAME);
      var response = await httpClient.PostAsJsonAsync<object>(rootPath, new object(), null, cancellationToken).ConfigureAwait(false);
      
      return await response.BuildResponseResult<object>(cancellationToken) != null;
   }
}
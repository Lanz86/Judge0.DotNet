namespace Judge0.DotNet.Options;

public class Judje0Options
{
    public  const string JudjeO = "Judje0";
    public string BaseUrl { get; set; } = string.Empty;
    public string AuthorizationHeader { get; set; } = "X-Auth-Token";
    public string AuthorizationToken { get; set; } = string.Empty;
    public string AuthenticationHeader { get; set; } = "X-Auth-User";
    public string AuthenticationToken { get; set; } = string.Empty;
}
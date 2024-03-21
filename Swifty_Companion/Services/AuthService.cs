using System.Text.Json;
using System.Text.Json.Serialization;

public class TokenResponse
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }

    [JsonPropertyName("token_type")]
    public string TokenType { get; set; }

    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; }

    [JsonPropertyName("scope")]
    public string Scope { get; set; }

    [JsonPropertyName("created_at")]
    public long CreatedAt { get; set; }

    [JsonPropertyName("secret_valid_until")]
    public long SecretValidUntil { get; set; }
}


public class School42OAuthOptions
{
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string CallbackPath { get; set; } = "swiftycompanion://signin-42";
    public string AuthorizationEndpoint { get; set; } = "https://api.intra.42.fr/oauth/authorize";
    public string TokenEndpoint { get; set; } = "https://api.intra.42.fr/oauth/token";
    public string UserInformationEndpoint { get; set; } = "https://api.intra.42.fr/v2/me";
    public List<string> Scope { get; set; } = new List<string> { "public" };
}

public class AuthService
{
    private readonly School42OAuthOptions _options;
    private HttpClient _httpClient = new();

    public AuthService(School42OAuthOptions options)
    {
        _options = options;
    }

    public async Task<string?> GetTokenAsync()
    {
        try
        {
            var authResult = await WebAuthenticator.AuthenticateAsync(
                new Uri($"{_options.AuthorizationEndpoint}?response_type=code&client_id={_options.ClientId}&redirect_uri={_options.CallbackPath}&scope={string.Join(" ", _options.Scope)}"),
                new Uri(_options.CallbackPath));

            return await ExtractToken(authResult);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Authentication failed: {ex.Message}");
            return null;
        }
    }

    private async Task<string?> ExtractToken(WebAuthenticatorResult result)
    {
        var content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            {"grant_type", "authorization_code"},
            {"client_id", _options.ClientId},
            {"client_secret", _options.ClientSecret},
            {"code", result.Properties["code"]},
            {"redirect_uri", _options.CallbackPath}
        });

        var response = await _httpClient.PostAsync(_options.TokenEndpoint, content);
        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();
        var responseData = JsonSerializer.Deserialize<TokenResponse>(responseString);
        if (responseData != null)
        {
            var accessToken = responseData.AccessToken;
            await SecureStorage.SetAsync("tokenresponse", JsonSerializer.Serialize(responseData));
            return accessToken;
        }
        return null;
    }

    public async Task<TokenResponse?> GetStoredTokenAsync()
    {
        var t = await SecureStorage.GetAsync("tokenresponse");
        if (t == null)
            return null;
        var token = JsonSerializer.Deserialize<TokenResponse>(t);
        if (token == null || token.ExpiresIn == 0)
            return null;
        return token;
    }

    public bool LogOut()
    {
        return SecureStorage.Remove("tokenresponse");
    }

    public async Task<bool> IsUserAuthenticatedAsync()
    {
        var token = await GetStoredTokenAsync();
        if (token == null)
            return false;

        return true;
    }

}

using System.Net.Http.Headers;
using System.Text.Json;
using Swifty_Companion.Services.SchoolApiClasses;

public class SchoolApiService
{
	private static HttpClient _client = new();
	private AuthService _school42AuthService;
	private User? _user = null;

	public SchoolApiService(AuthService school42AuthService)
	{
		_school42AuthService = school42AuthService;
	}

	public async Task<User?> GetSelfAsync()
	{
		if (_user != null)
			return _user;
		var oAuthToken = await _school42AuthService.GetStoredTokenAsync();
		if (oAuthToken == null)
			return null;
		Console.WriteLine(oAuthToken.AccessToken);
		_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", oAuthToken.AccessToken);
		var response = await _client.GetAsync("https://api.intra.42.fr/v2/me");
		if (!response.IsSuccessStatusCode)
			return null;

		var json = await response.Content.ReadAsStringAsync();
		try
		{
            User? user = JsonSerializer.Deserialize<User>(json);
            return user;
        }
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
			return null;
		}
		
    }
}
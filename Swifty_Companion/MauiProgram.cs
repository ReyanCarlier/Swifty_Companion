using System.Text.Json;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;

namespace Swifty_Companion;

public static class MauiProgram
{
    public static bool IsInternetAvailable()
    {
        var profiles = Connectivity.Current.NetworkAccess;
        return profiles == NetworkAccess.Internet;
    }

    public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
        var school42Options = new School42OAuthOptions
        {
            ClientId = "",
            ClientSecret = "",
        };
        builder.Services.AddMudServices();
        builder.Services.AddSingleton(school42Options);
        builder.Services.AddSingleton<AuthService>();
		builder.Services.AddSingleton<SchoolApiService>();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}


#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif

using Microsoft.AspNetCore.Components.WebView.Maui;
using irunsaapp.Data;
using MudBlazor.Services;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using Microsoft.Maui.LifecycleEvents;
using irunsaapp;
using Blazored.LocalStorage;
using irunsaapp.Services;
using Microsoft.AspNetCore.Components.Authorization;
using irunsaapp.Helper;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace irunsaapp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://irunsa.co.za/") });
        //builder.Services.AddScoped(sp => new HttpClient {BaseAddress= new Uri("https://localhost:7192/")});
      
        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddMudServices();
        builder.Services.Configure<KestrelServerOptions>(options =>
        {
            options.Limits.MaxRequestBodySize = 50 * 1024 * 1024; // 50 MB
        });
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif

        builder.ConfigureLifecycleEvents(events =>
        {
#if WINDOWS
                events.AddWindows(wndLifeCycleBuilder =>
                {
                    wndLifeCycleBuilder.OnWindowCreated(window =>
                    {
                        IntPtr nativeWindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                        WindowId win32WindowsId = Win32Interop.GetWindowIdFromWindow(nativeWindowHandle);
                        AppWindow winuiAppWindow = AppWindow.GetFromWindowId(win32WindowsId);

                        //https://github.com/dotnet/maui/issues/6976
                        var displayArea = Microsoft.UI.Windowing.DisplayArea.GetFromWindowId(win32WindowsId, Microsoft.UI.Windowing.DisplayAreaFallback.Nearest);
                        
                        int width = displayArea.WorkArea.Width * 2 / 3;
                        int height = displayArea.WorkArea.Height - 10;

                        winuiAppWindow.MoveAndResize(new RectInt32(15, 10, width, height));
                    });
                });
#endif
        });
        builder.Services.AddBlazoredLocalStorage();
        builder.Services.AddSingleton<IEntityType, EntityTypeService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddSingleton<WeatherForecastService>();
        builder.Services.AddSingleton<DataAccess>();
        builder.Services.AddSingleton<WeatherForecastService>();
        builder.Services.AddAuthorizationCore();
        builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();



        return builder.Build();
	}
}

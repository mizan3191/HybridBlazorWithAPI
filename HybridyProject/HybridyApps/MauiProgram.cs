using HybridyApps.MyServices;
using Microsoft.Extensions.Logging;

namespace HybridyApps
{
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

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddScoped<IMyHybridClassServices, MyHybridServices>();

            // Register HttpClient with a named configuration
            builder.Services.AddHttpClient<IMyHybridClassServices, MyHybridServices>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44390/api/");
            });

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

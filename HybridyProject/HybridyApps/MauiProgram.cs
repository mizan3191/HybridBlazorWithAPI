//using CommonUI.Services;
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
            //builder.Services.AddScoped<IMyClassServices, MyClassServices>();

            // Register HttpClient with a named configuration
            builder.Services.AddHttpClient<IMyHybridClassServices, MyHybridServices>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44390/api/");
            });

            // Add HttpClient
            builder.Services.AddHttpClient("API", client =>
            {
                client.BaseAddress = new Uri("https://localhost:44390/api/");
            });

            // Register the custom service to access the API
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("API"));


            // Register HttpClient with a named configuration
            //builder.Services.AddHttpClient<IMyClassServices, MyClassServices>(client =>
            //{
            //    client.BaseAddress = new Uri("https://localhost:44390/api/");
            //});

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

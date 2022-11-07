using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Windows;
using System.Windows.Input;
using UI.Business.Interface;
using UI.Business.Services;
using UI.Library.Infrastructure.ApiAgents.SearchApi;
using UI.Library.Infrastructure.Config;
using UI.Library.Infrastructure.Services.Web;
using UI.Library.Infrastructure.Services.Web.HttpResponse;
using UI.Shell.Commands;
using UI.Shell.ViewModels;

namespace UI.Shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? AppHost { get; set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                 .UseSerilog((host, loggerConfiguration) =>
                 {
                     loggerConfiguration.WriteTo.File("test.txt", rollingInterval: RollingInterval.Day)
                         .WriteTo.Debug()
                         .MinimumLevel.Error();
                 })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<SearchViewModel>();
                    services.AddTransient<IUrlSearchService, UrlSearchService>();
                    services.AddSingleton<ICommand, SearchCommand>();
                    services.AddSingleton<ISearchApiAgent, SearchApiAgent>();
                    services.AddSingleton<IHttpService, HttpService>();
                    services.AddSingleton<IHttpResponseProcessorFactory, HttpResponseProcessorFactory>();
                    services.AddSingleton<SearchApiConfig>();

                    services.AddSingleton<MainWindow>(s => new MainWindow()
                    {
                        DataContext = s.GetRequiredService<SearchViewModel>()
                    });

                }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            var startupScreen = AppHost.Services.GetRequiredService<MainWindow>();
            startupScreen.Show();

            base.OnStartup(e);
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            AppHost!.Dispose();

            base.OnExit(e);
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Smokeball.SalesTool.Contracts;
using Smokeball.SalesTool.Services;
using Smokeball.SalesTool.ViewModel;
using System.Windows;

namespace Smokeball.SalesTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddScoped<ISearchRelevanceService, SearchRelevanceService>();
            services.AddScoped<IHttpHelperService, HttpHelperService>();
            services.AddScoped<IDefaultParameterService, DefaultParameterService>();
            services.AddScoped<IKeyWordMatchService, KeyWordMatchService>();

            services.AddScoped<SearchRelevanceViewModel>();
        }
        protected void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}

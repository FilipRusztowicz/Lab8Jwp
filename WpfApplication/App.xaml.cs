using Data;
using HTTP;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider { get; private set; }
        public string token = Environment.GetEnvironmentVariable("TOKENG", EnvironmentVariableTarget.User);
        
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string myAppFolder = Path.Combine(appDataPath, "GeminiLogs");
            string logFilePath = Path.Combine(myAppFolder, "log.txt");

            serviceCollection.AddSingleton<IZawodnikRepository, XmlZawodnikRepository>();
            serviceCollection.AddSingleton<IKlientHtml, KlientHtml>();
            serviceCollection.AddSingleton<IDialogService, DialogService>();
            serviceCollection.AddSingleton<ILLMClient>(provider => new GeminiClient(token, logFilePath));
            serviceCollection.AddTransient<ZawodnikViewModel>(); 
            serviceCollection.AddTransient<AIViewModel>();
            ServiceProvider = serviceCollection.BuildServiceProvider();
            var mainWindowViewModel = ServiceProvider.GetRequiredService<ZawodnikViewModel>();

            var mainWindow = new MainWindow
            {
                DataContext = mainWindowViewModel
            };

            
        }
    }

}

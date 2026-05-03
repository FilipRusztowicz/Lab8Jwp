using Data;
using HTTP;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IZawodnikRepository, XmlZawodnikRepository>();
            serviceCollection.AddSingleton<ZawodnikViewModel>();
            serviceCollection.AddSingleton<IKlientHtml, KlientHtml>();
            serviceCollection.AddSingleton<IDialogService, DialogService>();
            serviceCollection.AddTransient<ZawodnikViewModel>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }

}

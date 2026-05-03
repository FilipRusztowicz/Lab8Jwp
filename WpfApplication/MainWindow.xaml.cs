using Data;
using HTTP;
using Microsoft.Identity.Client.Extensions.Msal;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ZawodnikViewModel();
        }

        private async void BtnStrona_Click(object sender, RoutedEventArgs e)
        {
         KlientHtml klientHtml = new KlientHtml();   
            string html = await klientHtml.PobierzStrone();   
            HtmlOkno okno = new HtmlOkno(html);
            okno.ShowDialog();
        }

        
    }
}
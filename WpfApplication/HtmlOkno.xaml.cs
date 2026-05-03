using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication
{
    /// <summary>
    /// Logika interakcji dla klasy HtmlOkno.xaml
    /// </summary>
    public partial class HtmlOkno : Window
    {
        public HtmlOkno(string html)
        {
            InitializeComponent();

            HtmlTextBox.Text = html;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
    /// Logika interakcji dla klasy AIWindow.xaml
    /// </summary>
    public partial class AIWindow : Window
    {
        
        public AIWindow()
        {
            InitializeComponent();
            ((INotifyCollectionChanged)ListaWiadomosci.Items).CollectionChanged += ListaWiadomosci_CollectionChanged;
        }

        private void ListaWiadomosci_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                ListaWiadomosci.ScrollIntoView(e.NewItems[0]);
            }
        }
    }
}

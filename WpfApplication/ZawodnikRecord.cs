using Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication
{
    public class ZawodnikRecord : ViewModelBase
    {
        private int _zawodnikId;
        public int ZawodnikId
        {
            get
            {
                return _zawodnikId;
            }
            set
            {
                _zawodnikId = value;
                OnPropertyChanged("Id");
            }
        }

        private string? _imie;
        public string? Imie
        {
            get
            {
                return _imie;
            }
            set
            {
                _imie = value;
                OnPropertyChanged("Name");
            }
        }

        private int _nrKoszulki;
        public int NrKoszulki
        {
            get
            {
                return _nrKoszulki;
            }
            set
            {
                _nrKoszulki = value;
                OnPropertyChanged("Age");
            }
        }

        private double _kondycja;
        public double Kondycja
        {
            get
            {
                return _kondycja;
            }
            set
            {
                _kondycja = value;
                OnPropertyChanged("Address");
            }
        }

        private bool _czyKontuzja;
        public bool CzyKontuzja
        {
            get
            {
                return _czyKontuzja;
            }
            set
            {
                _czyKontuzja = value;
                OnPropertyChanged("Contact");
            }
        }

        private ObservableCollection<ZawodnikRecord> _zawodnikRecords;
        public ObservableCollection<ZawodnikRecord> ZawodnikRecords
        {
            get
            {
                return _zawodnikRecords;
            }
            set
            {
                _zawodnikRecords = value;
                OnPropertyChanged("StudentRecords");
            }
        }

        public static ObservableCollection<ZawodnikRecord> StudentRecords { get; internal set; }

        private void ZawodnikModels_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("ZawodnikRecords");
        }
        public ZawodnikRecord()
        {
            ZawodnikRecords = new ObservableCollection<ZawodnikRecord>();
        }
    }
}

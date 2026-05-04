using HTTP;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApplication
{
    public class AIViewModel : ViewModelBase
    {
        public ILLMClient ilmKlient;
       public ObservableCollection<Wiadomosc> historia { get; set; }
        public ICommand WyslijCommand { get; }
        private string _wpisywanyTekst;
        public string WpisywanyTekst
        {
            get { return _wpisywanyTekst; }
            set
            {
                _wpisywanyTekst = value;
                OnPropertyChanged(nameof(WpisywanyTekst));
            }
        }
        public AIViewModel(ILLMClient k)
        {
            ilmKlient = k;
            historia = new ObservableCollection<Wiadomosc>();
            WyslijCommand = new RelayCommand(Wyslij, CanWyslij);
        }
        private async void Wyslij(object parametr)
        {

            var tekstUzytkownika = WpisywanyTekst;

            // 1. Dodanie wiadomości użytkownika
            historia.Add(new Wiadomosc { Rola = "Użytkownik", Tresc = tekstUzytkownika });
            WpisywanyTekst = string.Empty;

            

            try
            {
                // 2. Zapytanie do Gemini
                var odpowiedzAI = await ilmKlient.WyslijWiadomosc(tekstUzytkownika);

                // 3. Dodanie odpowiedzi do kolekcji
                historia.Add(new Wiadomosc { Rola = "Gemini", Tresc = odpowiedzAI });
            }
            catch (System.Exception ex)
            {
                historia.Add(new Wiadomosc { Rola = "System", Tresc = $"Błąd komunikacji: {ex.Message}" });
            }
         
        }

        private bool CanWyslij(object parametr)
        {
            return !string.IsNullOrWhiteSpace(WpisywanyTekst);
        }

        
        
    }
}

using Domain;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Data
{
    public class XmlZawodnikRepository : IZawodnikRepository
    {

        private  string _sciezka;
        private  XmlSerializer _serializer;

        public XmlZawodnikRepository()
        {
            _sciezka = StorageHelper.GetFilePath("zawodnicy.xml");
            _serializer = new XmlSerializer(typeof(List<Zawodnik>));
        }

        public void Serializuj()
        {
            Zawodnik z1 = new Zawodnik() { ZawodnikId=1,nrKoszulki=22,kondycja=2.2,czyKontuzja=false,imie="Ambroży"};
            FileStream fs = new FileStream("zawodnik.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(Zawodnik));
            serializer.Serialize(fs, z1);
            fs.Close();
        }

        public void Deserializuj()
        {
            FileStream fs = new FileStream("zawodnik.xml", FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(Zawodnik));
            Zawodnik z1 = (Zawodnik)serializer.Deserialize(fs);
            fs.Close ();
        }

        private List<Zawodnik> LoadData()
        {
            if (!File.Exists(_sciezka))
            {
                return new List<Zawodnik>(); 
            }

            using (FileStream fs = new FileStream(_sciezka, FileMode.Open))
            {
                return (List<Zawodnik>)_serializer.Deserialize(fs);
            }
        }

        
        private void SaveData(List<Zawodnik> zawodnicy)
        {
            using (FileStream fs = new FileStream(_sciezka, FileMode.Create))
            {
                _serializer.Serialize(fs, zawodnicy);
            }
        }

        public async Task<IEnumerable<Zawodnik>> GetAll()
        {
            var data = LoadData();
            return await Task.FromResult(data);
        }

        public async Task<Zawodnik> GetById(int id)
        {
            var data = LoadData();
            var zawodnik = data.FirstOrDefault(z => z.ZawodnikId == id);
            return await Task.FromResult(zawodnik);
        }

        public void Add(Zawodnik zawodnik)
        {
            var data = LoadData();

           
            zawodnik.ZawodnikId = data.Any() ? data.Max(z => z.ZawodnikId) + 1 : 1;

            data.Add(zawodnik);
            SaveData(data);
        }

        public void Update(Zawodnik zawodnik)
        {
            var data = LoadData();
            var existing = data.FirstOrDefault(z => z.ZawodnikId == zawodnik.ZawodnikId);

            if (existing != null)
            {
                existing.imie = zawodnik.imie;
                existing.kondycja = zawodnik.kondycja;
                existing.czyKontuzja = zawodnik.czyKontuzja;
                existing.nrKoszulki = zawodnik.nrKoszulki;
                SaveData(data);
            }
        }

        public void Delete(int id)
        {
            var data = LoadData();
            var toDelete = data.FirstOrDefault(z => z.ZawodnikId == id);

            if (toDelete != null)
            {
                data.Remove(toDelete);
                SaveData(data);
            }
        }
        
    }


}

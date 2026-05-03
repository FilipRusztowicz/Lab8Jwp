using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Data
{
    public class XmlZawodnikRepository
    {
        
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
        //zad B dokoncz
    }


}

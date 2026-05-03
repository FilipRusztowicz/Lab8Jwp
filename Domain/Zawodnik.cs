using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace Domain
{
    [Table("Zawodnicy")]

    public class Zawodnik
    {
        [XmlAttribute]
        public int ZawodnikId { get; set; }
        [XmlElement("NumerKoszulki")]
        public int nrKoszulki { get; set; }
        [XmlElement("Kondycja")]
        public double kondycja { get; set; }
        [XmlElement("CzyKontuzja")]
        public bool czyKontuzja { get; set; }
        [XmlElement("imie")]
        public string? imie { get; set; }

        public override string ToString()
        {
            string kontuzja;
            if (czyKontuzja)
            {
                kontuzja = "TAK";
            }
            else
            {
                kontuzja = "NIE";

            }
            return $"{ZawodnikId}. {imie} nr koszulki: {nrKoszulki} kondycja: {kondycja} czy kontuzjowany?:{kontuzja}";
        }


    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP
{
    public class Wiadomosc
    {
        public string Rola { get; set; }
        public string Tresc { get; set; }

        public override string ToString()
        {
            return $"Rola: {Rola} , Wiadomosc: {Tresc}";
        }
    }
}

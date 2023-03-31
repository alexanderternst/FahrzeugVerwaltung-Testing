using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FahrzeugVerwaltung.Fahrzeuge;

namespace FahrzeugVerwaltung.Verteilere
{
    public class VerteilerStub : IVerteiler
    {
        public List<Fahrzeug> Fahrzeuge { get; set; }

        public bool GetFahrzeugAntwort()
        {
            return false;
        }

        public bool KeinFahrzeugPlatz(Auftrag auftrag)
        {
            return false;
        }

        public bool KeinFahrzeugAkku(Auftrag auftrag)
        {
            return false;
        }
    }
}

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

        public bool getFahrzeugAntwort()
        {
            return false;
        }
    }
}

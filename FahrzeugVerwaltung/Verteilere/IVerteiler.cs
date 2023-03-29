using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FahrzeugVerwaltung.Fahrzeuge;

namespace FahrzeugVerwaltung.Verteilere
{
    public interface IVerteiler
    {
        List<Fahrzeug> Fahrzeuge { get; set; }
        bool getFahrzeugAntwort();
    }
}

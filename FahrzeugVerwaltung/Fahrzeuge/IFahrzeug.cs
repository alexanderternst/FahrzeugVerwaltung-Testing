using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrzeugVerwaltung.Fahrzeuge
{
    public interface IFahrzeug
    {
        int MaxContainers { get; set; }
        int CurrentContainers { get; set; }
        int Pos { get; set; }
        int Id { get; set; }
        int Akku { get; set; }

        bool GenugPlatz(Auftrag auftrag);
        bool GenugAkku(Auftrag auftrag);
        bool KorrekterEndStandort(Auftrag auftrag);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrzeugVerwaltung.Fahrzeuge
{
    public class Fahrzeug : IFahrzeug
    {
        public bool IsBroken { get; set; }
        public int MaxContainers { get; set; }
        public int CurrentContainers { get; set; }
        public int Pos { get; set; }
        public int Id { get; set; }

        public bool GenugPlatz(Auftrag auftrag)
        {
            if (IsBroken)
                throw new ExecutionEngineException("Fahrzeug ist kapputt.");
            if (auftrag.AnzahlContainer + CurrentContainers > MaxContainers)
                return false;
            else
                return true;
        }
    }
}

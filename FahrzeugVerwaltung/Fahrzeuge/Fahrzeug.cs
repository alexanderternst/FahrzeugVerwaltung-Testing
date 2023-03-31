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
        public int Akku { get; set; }

        public void IstKapputt()
        {
            if (IsBroken)
                throw new ExecutionEngineException("Fahrzeug ist kapputt.");
        }

        public bool GenugPlatz(Auftrag auftrag)
        {
            //if (IsBroken)
            //    throw new ExecutionEngineException("Fahrzeug ist kapputt.");
            if (auftrag.AnzahlContainer + CurrentContainers > MaxContainers)
                return false;
            else
                return true;
        }

        public bool GenugAkku(Auftrag auftrag)
        {
            //if (IsBroken)
            //    throw new ExecutionEngineException("Fahrzeug ist kapputt.");

            if (this.Akku > (auftrag.PosNach - auftrag.PosVon))
                return true;
            else
                return false;
        }

        public bool KorrekterEndStandort(Auftrag auftrag)
        {
            // In diesem Fall räpresentieren 0 = keinen Standort
            if (auftrag.PosNach == 0 || this.Pos == 0)
                throw new ExecutionEngineException("Fahrzeug oder Auftrag hat keinen Endstandort.");
            if (this.Pos == auftrag.PosNach)
                return true;
            else
                return false;
        }
    }
}

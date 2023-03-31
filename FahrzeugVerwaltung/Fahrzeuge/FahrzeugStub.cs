using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrzeugVerwaltung.Fahrzeuge
{
    public class FahrzeugStub : IFahrzeug
    {
        public bool IsBroken { get; set; }
        public int MaxContainers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int CurrentContainers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Pos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Akku { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool GenugPlatz(Auftrag auftrag)
        {
            return false;
        }

        public bool KorrekterEndStandort(Auftrag auftrag)
        {
            return false;
        }

        public bool GenugAkku(Auftrag auftrag)
        {
            return false;
        }
    }
}

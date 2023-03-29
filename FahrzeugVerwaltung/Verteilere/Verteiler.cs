using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FahrzeugVerwaltung.Fahrzeuge;

namespace FahrzeugVerwaltung.Verteilere
{
    public class Verteiler : IVerteiler
    {
        public List<Fahrzeug> Fahrzeuge { get; set; }

        public Verteiler(List<Fahrzeug> list)
        {
            this.Fahrzeuge = list;
        }

        public bool getFahrzeugAntwort()
        {
            bool overallResult = true;
            foreach (var fahrzeug in this.Fahrzeuge)
            {
                try
                {
                    Auftrag auftrag = new Auftrag { AnzahlContainer = 1 };
                    bool result = fahrzeug.GenugPlatz(auftrag);
                }
                catch (Exception ex) { overallResult = false; }
            }
            return overallResult;
        }
    }
}

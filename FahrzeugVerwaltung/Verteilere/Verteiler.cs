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

        public bool GetFahrzeugAntwort()
        {
            bool overallResult = true;
            foreach (var fahrzeug in this.Fahrzeuge)
            {
                try
                {
                    fahrzeug.IstKapputt();
                }
                catch (Exception ex) { overallResult = false; }
            }

            return overallResult;
        }

        public bool KeinFahrzeugPlatz(Auftrag auftrag)
        {
            bool overallResult = true;
            foreach (var fahrzeug in this.Fahrzeuge)
            {
                try
                {
                    bool result = fahrzeug.GenugPlatz(auftrag);
                    if (result)
                        overallResult = false;
                }
                catch (Exception ex) { overallResult = false; }
            }
            return overallResult;
        }

        public bool KeinFahrzeugAkku(Auftrag auftrag)
        {
            bool overallResult = true;
            foreach (var fahrzeug in this.Fahrzeuge)
            {
                try
                {
                    bool result = fahrzeug.GenugAkku(auftrag);
                    if (result)
                        overallResult = false;
                }
                catch (Exception ex) { overallResult = false; }
            }
            return overallResult;
        }
    }
}

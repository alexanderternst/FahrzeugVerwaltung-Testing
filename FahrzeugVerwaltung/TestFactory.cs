using FahrzeugVerwaltung.Fahrzeuge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FahrzeugVerwaltung.Verteilere;

namespace FahrzeugVerwaltung
{
    public class TestFactory
    {
        static bool isTest = false;

        public static IFahrzeug GetFahrzeug()
        {
            if (isTest)
            {
                return new FahrzeugStub();
            }
            else
            {
                return new Fahrzeug();
                //throw new NotImplementedException("Fahrzeug wurde nicht implementiert.");
            }
        }

        public static IVerteiler GetVerteilerMitKaputtenFahrzeugen()
        {
            var fahrzeugListe = new List<Fahrzeug>();
            fahrzeugListe.Add(new Fahrzeug { Id = 1, MaxContainers = 10, CurrentContainers = 8, Pos = 5 });
            fahrzeugListe.Add(new Fahrzeug { Id = 2, MaxContainers = 10, CurrentContainers = 7, Pos = 2 });
            fahrzeugListe.Add(new Fahrzeug { Id = 3, MaxContainers = 10, CurrentContainers = 5, Pos = 3, IsBroken = true });

            return new Verteiler(fahrzeugListe);
        }
        public static IVerteiler GetVerteiler()
        {
            if (isTest)
            {
                return new VerteilerStub();
            }
            else
            {
                var fahrzeugListe = new List<Fahrzeug>();
                fahrzeugListe.Add(new Fahrzeug { Id = 1, MaxContainers = 10, CurrentContainers = 8, Pos = 5 });
                fahrzeugListe.Add(new Fahrzeug { Id = 2, MaxContainers = 10, CurrentContainers = 7, Pos = 2 });
                fahrzeugListe.Add(new Fahrzeug { Id = 3, MaxContainers = 10, CurrentContainers = 5, Pos = 3, IsBroken = false });

                return new Verteiler(fahrzeugListe);
                //throw new NotImplementedException("Verteiler wurde nicht implementiert.");
            }
        }
    }
}

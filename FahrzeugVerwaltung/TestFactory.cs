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
        private const bool IsTest = false;

        public static IFahrzeug GetFahrzeug()
        {
            if (IsTest)
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
            fahrzeugListe.Add(new Fahrzeug { Id = 1, MaxContainers = 10, CurrentContainers = 8, Pos = 5, Akku = 50 });
            fahrzeugListe.Add(new Fahrzeug { Id = 2, MaxContainers = 10, CurrentContainers = 7, Pos = 2, Akku = 50 });
            fahrzeugListe.Add(new Fahrzeug { Id = 3, MaxContainers = 10, CurrentContainers = 5, Pos = 3, Akku = 50, IsBroken = true });

            return new Verteiler(fahrzeugListe);
        }

        public static IVerteiler GetVerteiler()
        {
            if (IsTest)
            {
                return new VerteilerStub();
            }
            else
            {
                var fahrzeugListe = new List<Fahrzeug>();
                fahrzeugListe.Add(new Fahrzeug { Id = 1, MaxContainers = 10, CurrentContainers = 8, Pos = 5, Akku = 50});
                fahrzeugListe.Add(new Fahrzeug { Id = 2, MaxContainers = 10, CurrentContainers = 7, Pos = 2, Akku = 50 });
                fahrzeugListe.Add(new Fahrzeug { Id = 3, MaxContainers = 10, CurrentContainers = 5, Pos = 3, IsBroken = false, Akku = 50 });

                return new Verteiler(fahrzeugListe);
                //throw new NotImplementedException("Verteiler wurde nicht implementiert.");
            }
        }
    }
}

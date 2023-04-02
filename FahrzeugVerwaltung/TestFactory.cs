namespace FahrzeugVerwaltung
{
    /// <summary>
    /// TestFactory für Ausführung von UnitTests und Methoden durch IVerteiler und IFahrzeug Interface.
    /// Diese Factory hat keine richtige Logik, sie dient nur zum Testen und instanziieren von Interfaces/Klassen.
    /// </summary>
    public class TestFactory
    {
        // Property welche bestimmt ob Test oder nicht.
        private const bool IsTest = false;

        /// <summary>
        /// Methode welche ein Fahrzeug durch Interface zurückgibt.
        /// Wenn IsTest true ist, wird ein FahrzeugStub zurückgegeben, sonst wird reale Implementierung zurückgegeben.
        /// </summary>
        /// <returns></returns>
        public static IFahrzeug GetFahrzeug()
        {
            if (IsTest)
            {
                return new FahrzeugStub();
            }
            else
            {
                return new Fahrzeug();
            }
        }

        /// <summary>
        /// Methode welche einen Verteiler durch Interface zurückgibt.
        /// Diesem Verteiler wird eine Liste von Fahrzeugen gegeben, bei welchen eines kaputt ist.
        /// </summary>
        /// <returns></returns>
        public static IVerteiler GetVerteilerMitKaputtenFahrzeugen()
        {
            var fahrzeugListe = new List<Fahrzeug>();
            fahrzeugListe.Add(new Fahrzeug { Id = 1, MaxContainers = 10, CurrentContainers = 8, Pos = 5, Akku = 50 });
            fahrzeugListe.Add(new Fahrzeug { Id = 2, MaxContainers = 10, CurrentContainers = 7, Pos = 2, Akku = 50 });
            fahrzeugListe.Add(new Fahrzeug { Id = 3, MaxContainers = 10, CurrentContainers = 5, Pos = 3, Akku = 50, IsBroken = true });

            return new Verteiler(fahrzeugListe);
        }

        /// <summary>
        /// Methode welche einen Verteiler durch Interface zurückgibt.
        /// Wenn IsTest true ist, wird ein VerteilerStub zurückgegeben, sonst wird reale Implementierung zurückgegeben.
        /// Bei der realen Implementierung wird eine Liste von Fahrzeugen gegeben, bei keine kaputt sind.
        /// </summary>
        /// <returns></returns>
        public static IVerteiler GetVerteiler()
        {
            if (IsTest)
            {
                return new VerteilerStub();
            }
            else
            {
                var fahrzeugListe = new List<Fahrzeug>();
                fahrzeugListe.Add(new Fahrzeug { Id = 1, MaxContainers = 10, CurrentContainers = 8, Pos = 5, Akku = 50 });
                fahrzeugListe.Add(new Fahrzeug { Id = 2, MaxContainers = 10, CurrentContainers = 7, Pos = 2, Akku = 50 });
                fahrzeugListe.Add(new Fahrzeug { Id = 3, MaxContainers = 10, CurrentContainers = 5, Pos = 3, Akku = 50, IsBroken = false });

                return new Verteiler(fahrzeugListe);
            }
        }
    }
}
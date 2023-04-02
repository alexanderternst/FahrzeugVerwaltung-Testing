namespace FahrzeugVerwaltung.Verteilere
{
    /// <summary>
    /// Verteiler Klasse welche das IVerteiler Interface implementiert.
    /// Implementiert die Methoden für den Verteiler.
    /// </summary>
    public class Verteiler : IVerteiler
    {
        public List<Fahrzeug> Fahrzeuge { get; set; }

        /// <summary>
        /// Verteiler Konstruktor welcher eine Liste von Fahrzeugen (von der Factory) bekommt.
        /// </summary>
        /// <param name="list"></param>
        public Verteiler(List<Fahrzeug> list)
        {
            this.Fahrzeuge = list;
        }

        /// <summary>
        /// Gibt eine Antwort zurück ob ein Fahrzeug kaputt ist.
        /// Wenn ein Fahrzeug kapputt ist wird false zurückgegeben, sonst wird true zurückgegeben.
        /// </summary>
        /// <returns></returns>
        public bool GetFahrzeugAntwort()
        {
            bool overallResult = true;
            foreach (var fahrzeug in this.Fahrzeuge)
            {
                try
                {
                    fahrzeug.IstKaputt();
                }
                catch (Exception) { overallResult = false; }
            }

            return overallResult;
        }

        /// <summary>
        /// Gibt eine Antwort zurück ob ein Fahrzeug genug Platz hat.
        /// Wenn alle Fahrzeuge keinen Platz haben wird true zurückgegeben, sonst wird false zurückgegeben.
        /// </summary>
        /// <param name="auftrag"></param>
        /// <returns></returns>
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
                catch (Exception) { overallResult = false; }
            }
            return overallResult;
        }

        /// <summary>
        /// Gibt eine Antwort zurück ob ein Fahrzeug genug Akku hat.
        /// Wenn alle Fahrzeuge keinen Akku haben wird true zurückgegeben, sonst wird false zurückgegeben.
        /// </summary>
        /// <param name="auftrag"></param>
        /// <returns></returns>
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
                catch (Exception) { overallResult = false; }
            }
            return overallResult;
        }
    }
}
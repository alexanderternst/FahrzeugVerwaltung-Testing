namespace FahrzeugVerwaltung.Fahrzeuge
{
    /// <summary>
    /// Fahrzeug Klasse welche das IFahrzeug Interface implementiert.
    /// Implementiert die Methoden und Properties für die Fahrzeuge.
    /// </summary>
    public class Fahrzeug : IFahrzeug
    {
        public bool IsBroken { get; set; }
        public int MaxContainers { get; set; }
        public int CurrentContainers { get; set; }
        public int Pos { get; set; }
        public int Id { get; set; }
        public int Akku { get; set; }

        /// <summary>
        /// Methode welche überprüft ob das Fahrzeug kapputt ist.
        /// </summary>
        /// <exception cref="ExecutionEngineException"></exception>
        public void IstKaputt()
        {
            if (IsBroken)
                throw new ExecutionEngineException("Fahrzeug ist kapputt.");
        }

        /// <summary>
        /// Methode welche überprüft ob das Fahrzeug genug Platz für Auftrag hat.
        /// </summary>
        /// <param name="auftrag"></param>
        /// <returns></returns>
        public bool GenugPlatz(Auftrag auftrag)
        {
            if (auftrag.AnzahlContainer + CurrentContainers > MaxContainers)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Methode welche überprüft ob das Fahrzeug genug Akku hat um den Auftrag zu erfüllen.
        /// </summary>
        /// <param name="auftrag"></param>
        /// <returns></returns>
        public bool GenugAkku(Auftrag auftrag)
        {
            if (this.Akku > (auftrag.PosNach - auftrag.PosVon))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Methode welche überprüft ob das Fahrzeug am richtigen Endstandort ist.
        /// </summary>
        /// <param name="auftrag"></param>
        /// <returns></returns>
        /// <exception cref="ExecutionEngineException"></exception>
        public bool KorrekterEndStandort(Auftrag auftrag)
        {
            if (auftrag.PosNach == 0 || this.Pos == 0)
                throw new ExecutionEngineException("Fahrzeug oder Auftrag hat keinen Endstandort.");
            if (this.Pos == auftrag.PosNach)
                return true;
            else
                return false;
        }
    }
}
namespace FahrzeugVerwaltung.Verteilere
{
    /// <summary>
    /// VerteilerStub Klasse welche das IVerteiler Interface implementiert.
    /// Wird für die UnitTests verwendet.
    /// </summary>
    public class VerteilerStub : IVerteiler
    {
        public List<Fahrzeug> Fahrzeuge { get; set; }

        public bool GetFahrzeugAntwort()
        {
            return false;
        }

        public bool KeinFahrzeugPlatz(Auftrag auftrag)
        {
            return false;
        }

        public bool KeinFahrzeugAkku(Auftrag auftrag)
        {
            return false;
        }
    }
}
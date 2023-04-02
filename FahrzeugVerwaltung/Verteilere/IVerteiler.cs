namespace FahrzeugVerwaltung.Verteilere
{
    /// <summary>
    /// Interface für den Verteiler.
    /// </summary>
    public interface IVerteiler
    {
        List<Fahrzeug> Fahrzeuge { get; set; }

        bool GetFahrzeugAntwort();

        bool KeinFahrzeugPlatz(Auftrag auftrag);

        bool KeinFahrzeugAkku(Auftrag auftrag);
    }
}
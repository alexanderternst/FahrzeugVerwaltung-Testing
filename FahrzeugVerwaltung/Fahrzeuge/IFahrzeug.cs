namespace FahrzeugVerwaltung.Fahrzeuge
{
    /// <summary>
    /// Interface für ein Fahrzeug.
    /// </summary>
    public interface IFahrzeug
    {
        bool IsBroken { get; set; }
        int MaxContainers { get; set; }
        int CurrentContainers { get; set; }
        int Pos { get; set; }
        int Id { get; set; }
        int Akku { get; set; }

        void IstKaputt();

        bool GenugPlatz(Auftrag auftrag);

        bool GenugAkku(Auftrag auftrag);

        bool KorrekterEndStandort(Auftrag auftrag);
    }
}
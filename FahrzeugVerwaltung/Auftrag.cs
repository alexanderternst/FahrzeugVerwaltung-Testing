namespace FahrzeugVerwaltung
{
    /// <summary>
    /// Auftrag Model Klasse für Aufträge.
    /// </summary>
    public class Auftrag
    {
        public int Id { get; set; }
        public int PosVon { get; set; }
        public int PosNach { get; set; }
        public int AnzahlContainer { get; set; }
    }
}
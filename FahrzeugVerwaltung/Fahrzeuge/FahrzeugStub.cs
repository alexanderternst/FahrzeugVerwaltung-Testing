namespace FahrzeugVerwaltung.Fahrzeuge
{
    /// <summary>
    /// FahrzeugStub Klasse welche das IFahrzeug Interface implementiert.
    /// Wird für die UnitTests verwendet.
    /// </summary>
    public class FahrzeugStub : IFahrzeug
    {
        public bool IsBroken { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int MaxContainers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int CurrentContainers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Pos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Akku { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void IstKaputt()
        {
            throw new NotImplementedException();
        }

        public bool GenugPlatz(Auftrag auftrag)
        {
            return false;
        }

        public bool KorrekterEndStandort(Auftrag auftrag)
        {
            return false;
        }

        public bool GenugAkku(Auftrag auftrag)
        {
            return false;
        }
    }
}
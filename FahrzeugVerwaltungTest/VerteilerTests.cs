namespace FahrzeugVerwaltungTest
{
    [TestClass]
    public class VerteilerTests
    {
        [TestMethod]
        public void FahrzeugGibtAntwort()
        {
            // Arrange
            IVerteiler verteiler = TestFactory.GetVerteiler();
            //IFahrzeug fahrzeug = TestFactory.GetFahrzeug();
            bool expectedResult = true; // Bei Stub auf false

            // Act
            bool result = verteiler.GetFahrzeugAntwort();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void FahrzeugKaputtGibtKeineAntwort()
        {
            // Arrange
            IVerteiler verteiler = TestFactory.GetVerteilerMitKaputtenFahrzeugen();
            //IFahrzeug fahrzeug = TestFactory.GetFahrzeug();
            bool expectedResult = false;

            // Act
            bool result = verteiler.GetFahrzeugAntwort();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void KeineFahrzeugeHabenPlatz()
        {
            IVerteiler verteiler = TestFactory.GetVerteiler();
            Auftrag auftrag = new Auftrag() { AnzahlContainer = 12 };
            bool expectedResult = true; // Bei Stub auf false

            // Act
            bool result = verteiler.KeinFahrzeugPlatz(auftrag);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void FahrzeugeHabenPlatz()
        {
            IVerteiler verteiler = TestFactory.GetVerteiler();
            Auftrag auftrag = new Auftrag() { AnzahlContainer = 3 };
            bool expectedResult = false;

            // Act
            bool result = verteiler.KeinFahrzeugPlatz(auftrag);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void KeineFahrzeugeHabenAkku()
        
        {
            // Arrange
            IVerteiler verteiler = TestFactory.GetVerteiler();
            Auftrag auftrag = new Auftrag() { AnzahlContainer = 12, PosVon = 1, PosNach = 100};
            bool expectedResult = true; // Bei Stub auf false
            // Act
            bool result = verteiler.KeinFahrzeugAkku(auftrag);
            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void FahrzeugeHabenAkku()
        {
            // Arrange
            IVerteiler verteiler = TestFactory.GetVerteiler();
            Auftrag auftrag = new Auftrag() { AnzahlContainer = 12, PosVon = 1, PosNach = 16 };
            bool expectedResult = false;
            // Act
            bool result = verteiler.KeinFahrzeugAkku(auftrag);
            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}

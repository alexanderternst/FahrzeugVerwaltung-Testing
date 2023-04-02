namespace FahrzeugVerwaltungTest
{
    /// <summary>
    /// TestKlasse welche die Verteiler Klasse testet.
    /// Wenn in Factory IsTest = true ist, wird die VerteilerStub Klasse verwendet und Tests laufen nicht durch.
    /// Bei 3 Methoden: FahrzeugKaputtGibtKeineAntwort(), FahrzeugeHabenPlatz(), FahrzeugeHabenAkku() läuft Test immer noch durch da Stub immer false zurückgibt.
    /// Bei diesen Methoden müssen die Tests angepasst werden.
    /// </summary>
    [TestClass]
    public class VerteilerTests
    {
        #region TestMethoden für GetFahrzeugAntwort()

        /// <summary>
        /// TestMethode welche die Methode GetFahrzeugAntwort() testet.
        /// Test erwartet true da Fahrzeuge vorhanden und nicht kapput sind.
        /// </summary>
        [TestMethod]
        public void FahrzeugGibtAntwort()
        {
            // Arrange
            IVerteiler verteiler = TestFactory.GetVerteiler();
            bool expectedResult = true; // Bei Stub auf false

            // Act
            bool result = verteiler.GetFahrzeugAntwort();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// TestMethode welche die Methode GetFahrzeugAntwort() testet.
        /// Test erwartet false da mindestens ein Fahrzeug kapput sind.
        /// </summary>
        [TestMethod]
        public void FahrzeugKaputtGibtKeineAntwort()
        {
            // Arrange
            IVerteiler verteiler = TestFactory.GetVerteilerMitKaputtenFahrzeugen();
            bool expectedResult = false;

            // Act
            bool result = verteiler.GetFahrzeugAntwort();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        #endregion TestMethoden für GetFahrzeugAntwort()

        #region TestMethoden für KeinFahrzeugPlatz()

        /// <summary>
        /// TestMethode welche die Methode KeinFahrzeugPlatz() testet.
        /// Test erwartet true da keine Fahrzeuge Platz für den Auftrag haben.
        /// </summary>
        [TestMethod]
        public void KeineFahrzeugeHabenPlatz()
        {
            // Arrange
            IVerteiler verteiler = TestFactory.GetVerteiler();
            Auftrag auftrag = new Auftrag() { Id = 1, AnzahlContainer = 15 };
            bool expectedResult = true; // Bei Stub auf false

            // Act
            bool result = verteiler.KeinFahrzeugPlatz(auftrag);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// TestMethode welche die Methode KeinFahrzeugPlatz() testet.
        /// Test erwartet false da mindestens ein Fahrzeug Platz für den Auftrag hat.
        /// </summary>
        [TestMethod]
        public void FahrzeugeHabenPlatz()
        {
            IVerteiler verteiler = TestFactory.GetVerteiler();
            Auftrag auftrag = new Auftrag() { Id = 1, AnzahlContainer = 3 };
            bool expectedResult = false;

            // Act
            bool result = verteiler.KeinFahrzeugPlatz(auftrag);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        #endregion TestMethoden für KeinFahrzeugPlatz()

        #region TestMethoden für KeinFahrzeugAkku()

        /// <summary>
        /// TestMethode welche die Methode KeinFahrzeugAkku() testet.
        /// Test erwartet true da keine Fahrzeuge Akku für den Auftrag haben.
        /// </summary>
        [TestMethod]
        public void KeineFahrzeugeHabenAkku()
        {
            // Arrange
            IVerteiler verteiler = TestFactory.GetVerteiler();
            Auftrag auftrag = new Auftrag() { Id = 1, AnzahlContainer = 3, PosVon = 1, PosNach = 80 };
            bool expectedResult = true; // Bei Stub auf false

            // Act
            bool result = verteiler.KeinFahrzeugAkku(auftrag);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// TestMethode welche die Methode KeinFahrzeugAkku() testet.
        /// Test erwartet false da mindestens ein Fahrzeug Akku für den Auftrag hatt.
        /// </summary>
        [TestMethod]
        public void FahrzeugeHabenAkku()
        {
            // Arrange
            IVerteiler verteiler = TestFactory.GetVerteiler();
            Auftrag auftrag = new Auftrag() { Id = 1, AnzahlContainer = 3, PosVon = 1, PosNach = 20 };
            bool expectedResult = false;

            // Act
            bool result = verteiler.KeinFahrzeugAkku(auftrag);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        #endregion TestMethoden für KeinFahrzeugAkku()
    }
}
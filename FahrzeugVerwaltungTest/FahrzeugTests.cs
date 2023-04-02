namespace FahrzeugVerwaltungTest
{
    /// <summary>
    /// TestKlasse welche die Fahrzeug Klasse testet.
    /// Wenn in Factory IsTest = true ist, wird die VerteilerStub Klasse verwendet und Tests laufen nicht durch.
    /// </summary>
    [TestClass]
    public class FahrzeugTests
    {
        #region TestMethoden für GenugPlatz()

        /// <summary>
        /// TestMethode welche die Methode GenugPlatz() testet.
        /// Test erwartet true da GenugPlatz vorhanden ist.
        /// </summary>
        [TestMethod]
        public void Fahrzeug_GenugPlatz()
        {
            // Arrange
            IFahrzeug fahrzeug = TestFactory.GetFahrzeug();
            fahrzeug.CurrentContainers = 0;
            fahrzeug.MaxContainers = 10;
            Auftrag auftrag = new Auftrag { Id = 1, PosVon = 1, PosNach = 2, AnzahlContainer = 1 };
            bool expectedResult = true;

            // Act
            bool result = fahrzeug.GenugPlatz(auftrag);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// TestMethode welche die Methode GenugPlatz() testet.
        /// Test erwartet false da nicht GenugPlatz vorhanden ist.
        /// </summary>
        [TestMethod]
        public void Fahrzeug_NichtGenugPlatz()
        {
            // Arrange
            IFahrzeug fahrzeug = TestFactory.GetFahrzeug();
            fahrzeug.CurrentContainers = 7;
            fahrzeug.MaxContainers = 10;
            Auftrag auftrag = new Auftrag { Id = 1, PosVon = 1, PosNach = 2, AnzahlContainer = 5 };
            bool expectedResult = false;

            // Act
            bool result = fahrzeug.GenugPlatz(auftrag);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        #endregion TestMethoden für GenugPlatz()

        #region TestMethoden für KorrekterEndStandort()

        /// <summary>
        /// TestMethode welche die Methode KorrekterEndStandort() testet.
        /// Test erwartet true da der Endstandort korrekt ist.
        /// </summary>
        [TestMethod]
        public void Fahrzeug_KorrekterEndStandort()
        {
            // Arrange
            IFahrzeug fahrzeug = TestFactory.GetFahrzeug();
            fahrzeug.Pos = 5;
            fahrzeug.MaxContainers = 10;

            Auftrag auftrag = new Auftrag { Id = 1, PosVon = 1, PosNach = 5, AnzahlContainer = 1 };
            bool expectedResult = true;

            // Act
            bool result = fahrzeug.KorrekterEndStandort(auftrag);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// TestMethode welche die Methode KorrekterEndStandort() testet.
        /// Test erwartet false da der Endstandort nicht korrekt ist.
        /// </summary>
        [TestMethod]
        public void Fahrzeug_FalscherEndStandort()
        {
            // Arrange
            IFahrzeug fahrzeug = TestFactory.GetFahrzeug();
            fahrzeug.Pos = 5;
            fahrzeug.MaxContainers = 10;

            Auftrag auftrag = new Auftrag { Id = 1, PosVon = 1, PosNach = 1, AnzahlContainer = 1 };
            bool expectedResult = false;

            // Act
            bool result = fahrzeug.KorrekterEndStandort(auftrag);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// TestMethode welche die Methode KorrekterEndStandort() testet.
        /// Test erwartet (durch ExceptedException) ExecutionEngineException Exception da kein Endstandort vorhanden ist.
        /// Deshalb fällt auch Assert weg.
        /// In diesem Fall ist 0 = Kein Standort.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ExecutionEngineException), "Fahrzeug oder Auftrag hat keinen Endstandort.")]
        public void Fahrzeug_KeinEndStandort()
        {
            // Arrange
            IFahrzeug fahrzeug = TestFactory.GetFahrzeug();
            fahrzeug.Pos = 0;
            fahrzeug.MaxContainers = 10;

            Auftrag auftrag = new Auftrag { Id = 1, PosVon = 1, PosNach = 0, AnzahlContainer = 1 };

            // Act
            fahrzeug.KorrekterEndStandort(auftrag);

            // Assert
            // Assert wird von ExpectedException Abgehandelt
        }

        #endregion TestMethoden für KorrekterEndStandort()

        #region TestMethoden für GenugAkku()

        /// <summary>
        /// TestMethode welche die Methode GenugAkku() testet.
        /// Test erwartet true da GenugAkku vorhanden ist.
        /// </summary>
        [TestMethod]
        public void Fahrzeug_GenugAkku()
        {
            // Arrange
            IFahrzeug fahrzeug = TestFactory.GetFahrzeug();
            fahrzeug.Pos = 2;
            // Ein Akku = Eine Position
            fahrzeug.Akku = 100;

            Auftrag auftrag = new Auftrag { Id = 1, PosVon = 1, PosNach = 20, AnzahlContainer = 1 };
            bool expectedResult = true;

            // Act
            bool result = fahrzeug.GenugAkku(auftrag);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// TestMethode welche die Methode GenugAkku() testet.
        /// Test erwartet false da nicht GenugAkku vorhanden ist.
        /// </summary>
        [TestMethod]
        public void Fahrzeug_ZuWenigAkku()
        {
            // Arrange
            IFahrzeug fahrzeug = TestFactory.GetFahrzeug();
            fahrzeug.Pos = 2;
            // Ein Akku = Eine Position
            fahrzeug.Akku = 10;

            Auftrag auftrag = new Auftrag { Id = 1, PosVon = 1, PosNach = 20, AnzahlContainer = 1 };
            bool expectedResult = false;

            // Act
            bool result = fahrzeug.GenugAkku(auftrag);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        #endregion TestMethoden für GenugAkku()

        #region TestMethode für IstKaputt()

        /// <summary>
        /// TestMethode welche die Methode IstKaputt() testet.
        /// Test erwartet (durch ExceptedException) ExecutionEngineException Exception da Fahrzeug kapputt ist.
        /// Deshalb fällt auch Assert weg.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ExecutionEngineException), "Fahrzeug ist kapputt.")]
        public void Fahrzeug_IstKaputt()
        {
            // Arrange
            IFahrzeug fahrzeug = TestFactory.GetFahrzeug();
            fahrzeug.IsBroken = true;

            // Act
            fahrzeug.IstKaputt();

            // Assert
            // Assert wird von ExpectedException Abgehandelt
        }

        #endregion TestMethode für IstKaputt()
    }
}
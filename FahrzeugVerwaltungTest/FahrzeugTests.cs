namespace FahrzeugVerwaltungTest
{
    [TestClass]
    public class FahrzeugTests
    {
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

        [TestMethod]
        public void Fahrzeug_KorrekterEndStandort()
        {
            // Arrange
            IFahrzeug fahrzeug = TestFactory.GetFahrzeug();
            fahrzeug.Pos = 1;
            fahrzeug.Id = 1;
            fahrzeug.CurrentContainers = 0;

            Auftrag auftrag = new Auftrag { Id = 1, PosVon = 1, PosNach = 1, AnzahlContainer = 1 };
            bool expectedResult = true;

            // Act
            bool result = fahrzeug.KorrekterEndStandort(auftrag);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Fahrzeug_FalscherEndStandort()
        {
            // Arrange
            IFahrzeug fahrzeug = TestFactory.GetFahrzeug();
            fahrzeug.Pos = 10;
            fahrzeug.Id = 1;
            fahrzeug.CurrentContainers = 0;

            Auftrag auftrag = new Auftrag { Id = 1, PosVon = 1, PosNach = 1, AnzahlContainer = 1 };
            bool expectedResult = false;

            // Act
            bool result = fahrzeug.KorrekterEndStandort(auftrag);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ExecutionEngineException), "Fahrzeug oder Auftrag hat keinen Endstandort.")]
        public void Fahrzeug_KeinEndStandort()
        {
            // Arrange
            IFahrzeug fahrzeug = TestFactory.GetFahrzeug();
            fahrzeug.Pos = 0;

            Auftrag auftrag = new Auftrag { PosNach = 0 };

            // Act
            bool result = fahrzeug.KorrekterEndStandort(auftrag);

            // Assert
            // Kein Assert wird von ExpectedException Abgehandelt
        }

        [TestMethod]
        public void Fahrzeug_GenugAkku()
        {
            // Arrange
            IFahrzeug fahrzeug = TestFactory.GetFahrzeug();
            // Ein Akku = Eine Position
            fahrzeug.Akku = 100;

            Auftrag auftrag = new Auftrag { PosVon = 1, PosNach = 2, AnzahlContainer = 1 };
            bool expectedResult = true;

            // Act
            bool result = fahrzeug.GenugAkku(auftrag);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Fahrzeug_ZuWenigAkku()
        {
            // Arrange
            IFahrzeug fahrzeug = TestFactory.GetFahrzeug();
            // Ein Akku = Eine Position
            fahrzeug.Akku = 1;

            Auftrag auftrag = new Auftrag { PosVon = 1, PosNach = 4, AnzahlContainer = 1 };
            bool expectedResult = false; // true bei stub

            // Act
            bool result = fahrzeug.GenugAkku(auftrag);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
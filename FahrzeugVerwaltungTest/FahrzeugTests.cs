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
    }
}
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
            bool expectedResult = true;

            // Act
            bool result = verteiler.getFahrzeugAntwort();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod("displayName")]
        public void FahrzeugKaputtGibtKeineAntwort()
        {
            // Arrange
            IVerteiler verteiler = TestFactory.GetVerteilerMitKaputtenFahrzeugen();
            //IFahrzeug fahrzeug = TestFactory.GetFahrzeug();
            bool expectedResult = false;

            // Act
            bool result = verteiler.getFahrzeugAntwort();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}

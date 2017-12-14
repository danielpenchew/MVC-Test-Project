using NUnit.Framework;

namespace LibrarySystem.Web.Controllers.Tests.HomeControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Have_Parameterless_Constructor()
        {
            // Arrange & Act
            HomeController sut = new HomeController();

            // Assert
            Assert.IsInstanceOf<HomeController>(sut);
        }
    }
}

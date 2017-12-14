using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace LibrarySystem.Web.Controllers.Tests.HomeControllerTests
{
    [TestFixture]
    public class Contact_Should
    {
        [Test]
        public void Return_Proper_ActionResult()
        {
            // Arrange
            HomeController sut = new HomeController();

            // Act & Assert
            sut.WithCallTo(x => x.Contact()).ShouldRenderDefaultView();
        }
    }
}

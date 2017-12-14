using LibrarySystem.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace LibrarySystem.Web.Controllers.Tests.BookControllerTests
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void Return_Correct_ActionResult()
        {
            // Arrange
            var serviceMock = new Mock<IBookServices>();
            var sut = new BookController(serviceMock.Object);

            // Act & Assert
            sut.WithCallTo(x => x.Create()).ShouldRenderDefaultView();
        }
    }
}

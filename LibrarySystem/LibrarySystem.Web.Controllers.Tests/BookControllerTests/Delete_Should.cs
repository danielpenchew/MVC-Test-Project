using LibrarySystem.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using TestStack.FluentMVCTesting;

namespace LibrarySystem.Web.Controllers.Tests.BookControllerTests
{
    [TestFixture]
    public class Delete_Should
    {
        [Test]
        public void Redirect_To_Proper_Url()
        {
            // Arrange
            Mock<IBookServices> serviceMock = new Mock<IBookServices>();
            Guid id = Guid.NewGuid();

            BookController sut = new BookController(serviceMock.Object);

            // Act & Assert
            sut.WithCallTo(x => x.Delete(id)).ShouldRedirectTo("/");
        }

        [Test]
        public void Throw_When_Passed_Id_Is_Empty()
        {
            // Arrange
            Mock<IBookServices> bookServicesMock = new Mock<IBookServices>();
            BookController sut = new BookController(bookServicesMock.Object);
            Guid invalidId = Guid.Empty;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => sut.Delete(invalidId));
        }
    }
}

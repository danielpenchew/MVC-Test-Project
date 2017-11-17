using LibrarySystem.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace LibrarySystem.Web.Controllers.Tests.BookControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedParametersAreNull()
        {
            // Arrange
            IBookServices bookServices = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new BookController(bookServices));
        }

        [Test]
        public void CreateInstanceOfBookServices_WhenParameterIsValid()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookServices>();

            // Act
            var bookController = new BookController(bookServiceMock.Object);

            // Assert
            Assert.IsInstanceOf<BookController>(bookController);
        }
    }
}

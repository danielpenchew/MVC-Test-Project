using LibrarySystem.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace LibrarySystem.Web.Controllers.Tests.BookControllerTests
{
    [TestFixture]
    public class Detail_Should
    {
        [Test]
        public void Invoke_BookServiceMethod_GetById_WhenPassedId_IsNotNull()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookServices>();
            var sut = new BookController(bookServiceMock.Object);

            // Act
            sut.Detail(Guid.NewGuid());

            // Assert
            bookServiceMock.Verify(b => b.GetById(It.IsAny<Guid>()), Times.Once);
        }
    }
}

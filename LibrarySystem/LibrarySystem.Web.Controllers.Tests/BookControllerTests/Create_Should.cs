using LibrarySystem.Data.Services.Contracts;
using LibrarySystem.Web.Models.BookModels;
using Moq;
using NUnit.Framework;
using System;
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

        [Test]
        public void Throw_ArgumentNullException_When_Passed_ViewModel_Is_Null()
        {
            // Arrange
            BookCreateViewModel viewModelNull = null;
            Mock<IBookServices> bookServiceMock = new Mock<IBookServices>();

            BookController sut = new BookController(bookServiceMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => sut.Create(viewModelNull));
        }
    }
}

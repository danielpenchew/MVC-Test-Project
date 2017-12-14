using LibrarySystem.Data.Services.Contracts;
using LibrarySystem.Web.Models.BookModels;
using LibrarySytem.Data.Models.Models;
using Moq;
using NUnit.Framework;
using System;
using TestStack.FluentMVCTesting;

namespace LibrarySystem.Web.Controllers.Tests.BookControllerTests
{
    [TestFixture]
    public class Edit_Should
    {
        [Test]
        public void Return_Correct_ActionResult()
        {
            // Arrange
            Mock<IBookServices> serviceMock = new Mock<IBookServices>();
            BookController sut = new BookController(serviceMock.Object);
            Guid testId = Guid.NewGuid();

            // Act & Assert
            sut.WithCallTo(x => x.Edit(testId)).ShouldRenderDefaultView();
        }

        [Test]
        public void Throw_NullReferenceException_When_Passed_ViewModel_IsNull()
        {
            // Arrange
            Mock<IBookServices> serviceMock = new Mock<IBookServices>();
            BookEditViewModel nullViewModel = null;
            Guid id = Guid.NewGuid();

            BookController sut = new BookController(serviceMock.Object);

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => sut.Edit(nullViewModel, id));
        }
        
        [Test]
        public void Throw_NullReferenceException_When_Passed_Id_IsEmpty()
        {
            // Arrange
            Mock<IBookServices> serviceMock = new Mock<IBookServices>();
            BookEditViewModel viewModel = new BookEditViewModel();
            Guid id = Guid.Empty;

            BookController sut = new BookController(serviceMock.Object);

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => sut.Edit(viewModel, id));
        }

        [Test]
        public void Redirect_To_Proper_Url_When_Passed_Parameters_Are_Valid()
        {
            // Arrange
            Mock<IBookServices> serviceMock = new Mock<IBookServices>();
            BookEditViewModel viewModel = new BookEditViewModel();
            Guid id = Guid.NewGuid();
            serviceMock.Setup(b => b.GetById(id)).Returns(new Book());

            BookController sut = new BookController(serviceMock.Object);
            
            // Act & Assert
            sut.WithCallTo(x => x.Edit(viewModel, id)).ShouldRedirectTo("/");
        }
    }
}

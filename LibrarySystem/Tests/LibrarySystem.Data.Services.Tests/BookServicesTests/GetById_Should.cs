using LibrarySystem.Data.Contracts;
using LibrarySytem.Data.Models.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Data.Services.Tests.BookServicesTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void BeCalledOnce_IfParametersAreValid()
        {
            // Arrange
            var dbSetMock = new Mock<ILibrarySystemEfWrapper<Book>>();
            var saveChangesMock = new Mock<ILibrarySystemEfDbContextSaveChanges>();
            var bookServices = new BookServices(dbSetMock.Object, saveChangesMock.Object);
            var bookMock = new Mock<Book>();

            // Act
            bookServices.GetById(bookMock.Object.Id);

            // Assert
            dbSetMock.Verify(r => r.GetById(bookMock.Object.Id), Times.Once);
        }

        [Test]
        public void ReturnTheProperBookWithId_IfCalled()
        {
            // Arrange
            var dbSetMock = new Mock<ILibrarySystemEfWrapper<Book>>();
            var saveChangesMock = new Mock<ILibrarySystemEfDbContextSaveChanges>();
            var bookServices = new BookServices(dbSetMock.Object, saveChangesMock.Object);
            var bookMock = new Mock<Book>();

            // Act
            dbSetMock.Setup(r => r.GetById(bookMock.Object.Id)).Returns(() => bookMock.Object);

            // Assert
            Assert.IsInstanceOf<Book>(bookServices.GetById(bookMock.Object.Id));
        }
    }
}

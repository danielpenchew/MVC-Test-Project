using LibrarySystem.Data.Contracts;
using LibrarySytem.Data.Models.Models;
using Moq;
using NUnit.Framework;

namespace LibrarySystem.Data.Services.Tests.BookServicesTests
{
    [TestFixture]
    public class DeleteBookById_Should
    {
        [Test]
        public void BeCalledOnce_IfPassedBookIsValid()
        {
            // Arrange
            var dbSetMock = new Mock<ILibrarySystemEfWrapper<Book>>();
            var saveChangesMock = new Mock<ILibrarySystemEfDbContextSaveChanges>();
            var bookServices = new BookServices(dbSetMock.Object, saveChangesMock.Object);
            var bookToDeleteMock = new Mock<Book>();

            // Act
            bookServices.AddBook(bookToDeleteMock.Object);
            bookServices.DeleteBookById(bookToDeleteMock.Object.Id);

            // Assert
            dbSetMock.Verify(r => r.Delete(bookToDeleteMock.Object.Id), Times.Once);
        }
    }
}

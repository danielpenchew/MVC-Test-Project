using LibrarySystem.Data.Contracts;
using LibrarySytem.Data.Models.Models;
using Moq;
using NUnit.Framework;

namespace LibrarySystem.Data.Services.Tests.BookServicesTests
{
    [TestFixture]
    public class DeleteBook_Should
    {
        [Test]
        public void BeCalled_IfPassedBookIsValid()
        {
            // Arrange
            var dbSetMock = new Mock<ILibrarySystemEfWrapper<Book>>();
            var saveChangesMock = new Mock<ILibrarySystemEfDbContextSaveChanges>();
            var bookServices = new BookServices(dbSetMock.Object, saveChangesMock.Object);
            var bookToWorkWithMock = new Mock<Book>();

            // Act
            bookServices.AddBook(bookToWorkWithMock.Object);
            bookServices.DeleteBook(bookToWorkWithMock.Object);

            // Assert
            dbSetMock.Verify(r => r.Delete(bookToWorkWithMock.Object), Times.Once);
        }
    }
}

using LibrarySystem.Data.Contracts;
using LibrarySytem.Data.Models.Models;
using Moq;
using NUnit.Framework;

namespace LibrarySystem.Data.Services.Tests.BookServicesTests
{
    [TestFixture]
    public class AddBook_Should
    {
        [Test]
        public void BeCalledOnce_IfBookIsValid()
        {
            // Arrange
            var dbSetMock = new Mock<ILibrarySystemEfWrapper<Book>>();
            var saveChangesMock = new Mock<ILibrarySystemEfDbContextSaveChanges>();
            var bookMock = new Mock<Book>();

            // Act
            var bookServices = new BookServices(dbSetMock.Object, saveChangesMock.Object);
            bookServices.AddBook(bookMock.Object);

            // Assert
            dbSetMock.Verify(s => s.Add(bookMock.Object), Times.Once);
        }

        [Test]
        public void CallSaveChangesOnce_IfBookIsValid()
        {
            // Arrange
            var dbSetMock = new Mock<ILibrarySystemEfWrapper<Book>>();
            var saveChangesMock = new Mock<ILibrarySystemEfDbContextSaveChanges>();
            var bookMock = new Mock<Book>();

            // Act
            var bookServices = new BookServices(dbSetMock.Object, saveChangesMock.Object);
            bookServices.AddBook(bookMock.Object);

            // Assert
            saveChangesMock.Verify(s => s.SaveChanges(), Times.Once);
        }
    }
}

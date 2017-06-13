using LibrarySystem.Data.Contracts;
using LibrarySytem.Data.Models.Models;
using Moq;
using NUnit.Framework;

namespace LibrarySystem.Data.Services.Tests.BookServicesTests
{
    [TestFixture]
    public class UpdateBook_Should
    {
        [Test]
        public void BeCalledOnce_IfBookIsValid()
        {
            // Arrange
            var dbSetMock = new Mock<ILibrarySystemEfWrapper<Book>>();
            var saveChangesMock = new Mock<ILibrarySystemEfDbContextSaveChanges>();
            var bookServices = new BookServices(dbSetMock.Object, saveChangesMock.Object);
            var bookMock = new Mock<Book>();

            // Act
            bookServices.UpdateBook(bookMock.Object);

            // Assert
            dbSetMock.Verify(r => r.Update(bookMock.Object), Times.Once);
        }
    }
}

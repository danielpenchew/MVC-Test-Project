using LibrarySystem.Data.Contracts;
using LibrarySytem.Data.Models.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem.Data.Services.Tests.BookServicesTests
{
    [TestFixture]
    public class GetAllBooks_Should
    {
        [Test]
        public void ReturnCorrectCollection_IfCalled()
        {
            // Arrange
            var dbSetMock = new Mock<ILibrarySystemEfWrapper<Book>>();
            var saveChangesMock = new Mock<ILibrarySystemEfDbContextSaveChanges>();
            var bookServices = new BookServices(dbSetMock.Object, saveChangesMock.Object);

            // Act
            IEnumerable<Book> expectedCollection = new List<Book>() { new Book(), new Book() };
            dbSetMock.Setup(rep => rep.All()).Returns(() => expectedCollection.AsQueryable());

            // Assert
            Assert.AreEqual(bookServices.GetAllBooks(), expectedCollection);
        }
    }
}

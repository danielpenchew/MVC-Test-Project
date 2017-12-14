using LibrarySystem.Data.Contracts;
using LibrarySytem.Data.Models.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem.Data.Services.Tests.AuthorServicesTests
{
    [TestFixture]
    public class GetAllAuthors_Should
    {
        [Test]
        public void ReturnInstanceOfIQueryable_IfCalled()
        {
            // Arrange
            var dbSetMock = new Mock<ILibrarySystemEfWrapper<Author>>();
            AuthorServices authorServices = new AuthorServices(dbSetMock.Object);

            // Act
            IEnumerable<Author> expectedResult = new List<Author>() { new Author(), new Author(), new Author() };
            dbSetMock.Setup(r => r.All()).Returns(() => expectedResult.AsQueryable());

            // Assert
            Assert.IsInstanceOf<IQueryable<Author>>(authorServices.GetAllAuthors());
        }
    }
}

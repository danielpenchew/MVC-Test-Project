using LibrarySystem.Data.Contracts;
using LibrarySytem.Data.Models.Models;
using Moq;
using NUnit.Framework;

namespace LibrarySystem.Data.Services.Tests.AuthorServicesTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void ReturnCorrectAuthor_WhenIdIsCorrect()
        {
            // Arrange
            var dbSetMock = new Mock<ILibrarySystemEfWrapper<Author>>();
            AuthorServices authorServices = new AuthorServices(dbSetMock.Object);
            var authorWithId = new Mock<Author>();

            // Act
            authorServices.GetById(authorWithId.Object.Id);

            // Assert
            dbSetMock.Verify(r => r.GetById(authorWithId.Object.Id), Times.Once);
        }
    }
}

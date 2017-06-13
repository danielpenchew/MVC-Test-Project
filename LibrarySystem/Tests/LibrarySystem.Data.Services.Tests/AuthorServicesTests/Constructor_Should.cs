using LibrarySystem.Data.Contracts;
using LibrarySytem.Data.Models.Models;
using Moq;
using NUnit.Framework;

namespace LibrarySystem.Data.Services.Tests.AuthorServicesTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateInstanceOfAuthorServices_IfParametersAreValid()
        {
            // Arrange & Act
            var dbSetMock = new Mock<ILibrarySystemEfWrapper<Author>>();
            var authorServices = new AuthorServices(dbSetMock.Object);

            // Assert
            Assert.That(authorServices, Is.Not.Null.And.InstanceOf<AuthorServices>());
        }
    }
}

using LibrarySystem.Data.Contracts;
using LibrarySytem.Data.Models.Models;
using Moq;
using NUnit.Framework;

namespace LibrarySystem.Data.Services.Tests.ImageServicesTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void ReturnCorrectImage_IfPassedIdIsCorrect()
        {
            // Arrange
            var dbSetMock = new Mock<ILibrarySystemEfWrapper<Image>>();
            var imageServices = new ImageServices(dbSetMock.Object);
            var imageMock = new Mock<Image>();

            // Act
            imageServices.GetById(imageMock.Object.Id);

            // Assert
            dbSetMock.Verify(r => r.GetById(imageMock.Object.Id), Times.Once);
        }
    }
}

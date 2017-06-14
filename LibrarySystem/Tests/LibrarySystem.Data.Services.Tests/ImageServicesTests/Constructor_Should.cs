using LibrarySystem.Data.Contracts;
using LibrarySytem.Data.Models.Models;
using Moq;
using NUnit.Framework;

namespace LibrarySystem.Data.Services.Tests.ImageServicesTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateInstance_IfPassedParameterIsCorrect()
        {
            // Arrange & Act
            var dbSetMock = new Mock<ILibrarySystemEfWrapper<Image>>();
            var imageServices = new ImageServices(dbSetMock.Object);

            // Assert
            Assert.That(imageServices, Is.Not.Null.And.InstanceOf<ImageServices>());
        }
    }
}

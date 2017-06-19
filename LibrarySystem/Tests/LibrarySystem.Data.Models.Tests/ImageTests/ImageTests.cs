using LibrarySytem.Data.Models.Models;
using NUnit.Framework;

namespace LibrarySystem.Data.Models.Tests.ImageTests
{
    [TestFixture]
    public class ImageTests
    {
        [Test]
        public void Constructor_ShouldHaveParameterlessConstructor()
        {
            // Arrange & Act
            Image image = new Image();

            // Assert
            Assert.IsInstanceOf<Image>(image);
        }

        [TestCase("1.jpg")]
        [TestCase("2.jpg")]
        public void Title_ShouldGetAndSetDataCorrectle(string title)
        {
            // Arrange & Act
            Image image = new Image() { Title = title };

            // Assert
            Assert.AreEqual(image.Title, title);
        }

        [Test]
        public void Book_ShouldGetAndSetDataCorrectly()
        {
            // Arrange & Act
            Book book = new Book();
            Image image = new Image() { Book = book };

            // Assert
            Assert.AreSame(image.Book, book);
        }

        [Test]
        public void ImageData_ShouldGetAndSetDataCorrectly()
        {
            // Arrange & Act
            var data = new byte[5];
            Image image = new Image() { ImageData = data };

            // Assert
            Assert.IsInstanceOf<byte[]>(image.ImageData);
        }
    }
}

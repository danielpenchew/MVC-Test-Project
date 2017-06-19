using LibrarySytem.Data.Models.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace LibrarySystem.Data.Models.Tests.UserTests
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void Books_ShouldGetAndSetDataCorrectly()
        {
            // Arrange & Act
            HashSet<Book> books = new HashSet<Book>();
            User user = new User() { Books = books };

            // Assert
            Assert.AreSame(user.Books, books);
        }
    }
}

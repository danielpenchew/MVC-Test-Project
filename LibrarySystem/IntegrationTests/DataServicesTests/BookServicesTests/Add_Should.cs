using LibrarySystem.Data;
using LibrarySystem.Data.Contracts;
using LibrarySystem.Data.Repositories;
using LibrarySystem.Data.Services;
using LibrarySystem.Data.Services.Contracts;
using LibrarySytem.Data.Models.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.Transactions;
using System.Linq;

namespace DataServicesTests.BookServicesTests
{
    [TestClass]
    public class Add_Should
    {
        private const string ConnectionString = "Data Source=.;Initial Catalog=LibrarySystemDb-SIT;Integrated Security=True;MultipleActiveResultSets=true";
        private static LibrarySystemEfDbContext dbContext = new LibrarySystemEfDbContext();

        ILibrarySystemEfWrapper<Book> repository = new LibrarySystemEfWrapper<Book>(dbContext);
        ILibrarySystemEfDbContextSaveChanges saveChanges = new LibrarySystemEfDbContextSaveChanges(dbContext);

        private static Author author = new Author()
        {
            FirstName = "AuthorFirstasd",
            LastName = "AuthorLastasd"
        };

        private static User user = new User()
        {
            UserName = "Pesho Peshovasd"
        };

        private static Book book = new Book()
        {
            Title = "TransactionTitle",
            Description = "TransactionDescription",
            Author = author,
            AuthorId = author.Id,
            User = user,
            UserId = user.Id
        };

        [TestMethod]
        public void Insert_Proper_Entity_In_Collection()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Arrange
                    IBookServices sut = new BookServices(repository, saveChanges);
                    
                    // Act
                    sut.AddBook(book);

                    // Assert
                    CollectionAssert.Contains(sut.GetAllBooks().ToList(), book);
                }
            }
        }
    }
}

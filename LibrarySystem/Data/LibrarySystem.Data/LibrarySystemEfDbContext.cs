using LibrarySystem.Data.Contracts;
using LibrarySytem.Data.Models.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LibrarySystem.Data
{
    public class LibrarySystemEfDbContext : IdentityDbContext<User>, ILibrarySystemEfDbContext
    {
        public LibrarySystemEfDbContext()
            : base("LibrarySystemDb")
        {
        }

        public IDbSet<Author> Authors { get; set; }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Image> Images { get; set; }

        public static LibrarySystemEfDbContext Create()
        {
            return new LibrarySystemEfDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}

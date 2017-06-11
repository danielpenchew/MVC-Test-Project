using Bytes2you.Validation;
using LibrarySystem.Data.Contracts;

namespace LibrarySystem.Data.Repositories
{
    public class LibrarySystemEfDbContextSaveChanges : ILibrarySystemEfDbContextSaveChanges
    {
        private readonly ILibrarySystemEfDbContext context;

        public LibrarySystemEfDbContextSaveChanges(ILibrarySystemEfDbContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}

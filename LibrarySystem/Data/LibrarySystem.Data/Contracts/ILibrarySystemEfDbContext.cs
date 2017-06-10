using LibrarySytem.Data.Models.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace LibrarySystem.Data.Contracts
{
    public interface ILibrarySystemEfDbContext : IDisposable
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Author> Authors { get; set; }

        IDbSet<Book> Books { get; set; }

        int SaveChanges();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}

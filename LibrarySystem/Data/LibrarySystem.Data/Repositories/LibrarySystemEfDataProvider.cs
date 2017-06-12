using Bytes2you.Validation;
using LibrarySystem.Data.Contracts;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace LibrarySystem.Data.Repositories
{
    public class LibrarySystemEfWrapper<T> : ILibrarySystemEfWrapper<T> where T : class
    {
        public LibrarySystemEfWrapper(ILibrarySystemEfDbContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        public ILibrarySystemEfDbContext Context { get; set; }

        public IDbSet<T> DbSet { get; set; }

        public void Add(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(entity);
            }
        }

        public IQueryable<T> All()
        {
            return this.DbSet.AsQueryable();
        }

        public void Delete(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Add(entity);
                this.DbSet.Remove(entity);
            }
        }

        public void Delete(Guid id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public T GetById(Guid id)
        {
            return this.DbSet.Find(id);
        }

        public void Update(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public void Dispose()
        {
            this.Context.SaveChanges();
        }
    }
}

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

        public virtual void Add(T entity)
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

        public virtual IQueryable<T> All()
        {
            return this.DbSet.AsQueryable();
        }

        public virtual void Delete(T entity)
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

        public virtual void Delete(Guid id)
        {
            T entity = this.GetById(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public virtual T GetById(Guid? id)
        {
            return this.DbSet.Find(id);
        }

        public virtual void Update(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }
    }
}

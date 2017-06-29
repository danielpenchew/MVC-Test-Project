using System;
using System.Linq;

namespace LibrarySystem.Data.Contracts
{
    public interface ILibrarySystemEfWrapper<T> where T : class
    {
        IQueryable<T> All();

        void Add(T entity);

        T GetById(Guid id);

        void Delete(Guid id);

        void Delete(T entity);

        void Update(T entity);
    }
}

using System;
using System.Collections.Generic;

namespace Students.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T GetById(Guid id);

        T AddNew(T item);

        T Update(T item);

        void Delete(T item);
    }
}

using System;
using System.Collections.Generic;

namespace Domain.Interface
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T Entity);
        void Remove(T Entity);
        void Delete(T Entity);

    }
}

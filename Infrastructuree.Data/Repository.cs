using Domain.Interface;
using Infrastructuree.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructuree.Data
{
    public class Repository<T> : IRepository<T> where T:class
    {
        public BakeryContext context;
        public Repository(BakeryContext context)
        {
            this.context = context;
        }
        public void Add(T Entity) { 
        context.Set<T>().Add(Entity);
        context.SaveChanges();
        }

    public void Delete(T Entity)
    {
        if (Entity == null)
        {
            throw new ArgumentNullException("Entity");
        }
        context.Set<T>().Remove(Entity);
        context.SaveChanges();
    }

    public T Get(int id)
    {
        return context.Set<T>().Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return context.Set<T>().AsEnumerable();
    }

    public void Remove(T Entity)
    {
        if (Entity == null)
        {
            throw new ArgumentNullException("Entity");
        }
        context.Set<T>().Remove(Entity);
        context.SaveChanges();
    }
}
}

using System;
using System.Collections.Generic;

namespace CoreImplementation.Database.Interfaces
{
    public interface IDBEntityCollection
    {
        void Initialize();
    }
    public interface IDBEntityCollection<T> : IDBEntityCollection
        where T: IDBEntity
    {
        void Add(T entity);
        void Remove(T entity);
        IEnumerable<T> Find(Func<T, bool> predicate);


    }
}
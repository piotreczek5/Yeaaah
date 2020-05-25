using System;
using System.Collections.Generic;

namespace CoreImplementation.Database.Interfaces
{
    public interface IDBEntityCollection<T>
        where T: IDBEntity
    {
        void Add(T entity);
        void Remove(T entity);
        IEnumerable<T> Find(Func<T, bool> predicate);
        void Initialize();


    }
}
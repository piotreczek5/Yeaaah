using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreImplementation.Database.Interfaces;

namespace CoreImplementation.Database.Implementation
{
    public class StandardDBEntityCollection <T>
        where T: IDBEntity
    {
        private IList<T> Entities;

        public StandardDBEntityCollection()
        {
        }


        public void Add(T entity)
        {
            Entities.Add(entity);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return Entities.Where(predicate);
        }

        public void Initialize()
        {
            Entities = new List<T>();
        }

        public void Remove(T entity)
        {
            Entities.Remove(entity);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using Core.Entities;
using CoreImplementation.Database.Implementation;
using CoreImplementation.Database.Interfaces;

namespace CoreImplementation.Database.Implementation
{
    public class StandardDatabase : IDataBase
    {
        private IDictionary<string, IDBEntityCollection> EntityCollections;

        public StandardDatabase()
        {
            EntityCollections = new Dictionary<string, IDBEntityCollection>();
        }
        
        public IDBEntityCollection<T> GetByType<T>()
            where T: IDBEntity
        {
            IDBEntityCollection dbEntityCollection = null;
            EntityCollections.TryGetValue(nameof(T), out dbEntityCollection);
            if(dbEntityCollection == null)
            {
                throw new CollectionNotRegisteredException($"Collection {nameof(T)} not found in Database");
            }

            return dbEntityCollection as IDBEntityCollection<T>;
        }

        public void Initialize()
        {
        }

        public void Register(IDBEntityCollection collection)
        {
            collection.Initialize();
            EntityCollections.TryAdd(nameof(collection), collection);
        }

        public void SaveToFile(string path)
        {
            throw new NotImplementedException();
        }
    }
}

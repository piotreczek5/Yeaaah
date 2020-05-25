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
        private IDictionary<string, StandardDBEntityCollection<IDBEntity>> EntityCollections;

        public static IEnumerable<StandardDBEntityCollection<IDBEntity>> GetCoreEntities() =>
           new []
            {
                new StandardDBEntityCollection<MenuItem>()
            };

        public StandardDatabase()
        {
            EntityCollections = new Dictionary<string, StandardDBEntityCollection<IDBEntity>>();
            //EntityCollections.Add(nameof(MenuItem), new StandardDBEntityCollection<TestEntity>());
            //var d = new StandardDBEntityCollection<MenuItem>();
        }
        
        public StandardDBEntityCollection<T> GetByType<T>()
            where T: IDBEntity
        {
            StandardDBEntityCollection<IDBEntity> dbEntityCollection = null;
            EntityCollections.TryGetValue(nameof(T), out  dbEntityCollection);
            if(dbEntityCollection == null)
            {
                throw new CollectionNotRegisteredException($"Collection {nameof(T)} not found in Database");
            }

            return dbEntityCollection as StandardDBEntityCollection<T>;
        }

        public void Initialize()
        {
        }

        public void Register(StandardDBEntityCollection<IDBEntity> collection)
        {
            EntityCollections.TryAdd(nameof(collection), collection);
        }

        public void SaveToFile(string path)
        {
            throw new NotImplementedException();
        }
    }
}

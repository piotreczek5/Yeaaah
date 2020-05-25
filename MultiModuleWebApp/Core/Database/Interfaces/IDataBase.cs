using System;
using System.Collections.Generic;
using System.Text;
using CoreImplementation.Database.Implementation;

namespace CoreImplementation.Database.Interfaces
{
    public interface IDataBase
    {
        void Register(StandardDBEntityCollection<IDBEntity> collection);
        StandardDBEntityCollection<T> GetByType<T>() where T :IDBEntity;
        void SaveToFile(string path);
        void Initialize();
    }
}

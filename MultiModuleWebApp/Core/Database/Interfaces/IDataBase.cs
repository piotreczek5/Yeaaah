using System;
using System.Collections.Generic;
using System.Text;
using CoreImplementation.Database.Implementation;

namespace CoreImplementation.Database.Interfaces
{
    public interface IDataBase
    {
        void Register(IDBEntityCollection collection);
        IDBEntityCollection<T> GetByType<T>() where T :IDBEntity;
        void SaveToFile(string path);
        void Initialize();
    }
}

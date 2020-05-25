using System.Collections.Generic;
using Core.Entities;
using CoreImplementation.Database;
using CoreImplementation.Database.Interfaces;

namespace Core
{
    public interface IProgramFeature
    {
        IEnumerable<MenuItem> MenuItems { get; }
        IDBEntityCollection<IDBEntity> EntityCollection { get; }
        void Initialize();
    }
}
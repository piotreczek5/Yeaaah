using CoreImplementation.Database;
using CoreImplementation.Database.Interfaces;

namespace Core.Entities
{
    public interface IMenuItem  : IDBEntity
    {
        string Identity { get; }
    }
}
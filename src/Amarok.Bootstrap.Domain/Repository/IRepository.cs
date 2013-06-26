using Amarok.Bootstrap.Domain.Entities;
using System.Collections.Generic;

namespace Amarok.Bootstrap.Domain.Repository
{
    public interface IRepository<T> where T : Entity
    {
        void Add<T>(T item);
        void Delete<T>(T item);
        void Update<T>(T item);
        T Get<T>(long id);
        IEnumerable<T> All();
        void Save<T>(T item);
    }
}

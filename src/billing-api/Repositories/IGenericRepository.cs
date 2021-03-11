using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.API.Repositories
{
    internal interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        Task Save();
    }
}
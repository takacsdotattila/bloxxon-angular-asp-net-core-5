using Billing.API.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.API.Repositories
{
    public class GenericSalesRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly SalesContext _context;
        protected readonly DbSet<T> _table;
        
        public GenericSalesRepository(SalesContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetById(object id)
        {
            return _table.Find(id);
        }

        public void Insert(T obj)
        {
            _table.Add(obj);
        }

        public void Update(T obj)
        {
            _table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            if (!(id is T obj))
            {
                obj = _table.Find(id);
            }
            _table.Remove(obj);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Metrics.Example.Models.Repositories
{
    public interface IRepository<T>
    {
        Task Insert(T entity);

        Task Insert(IEnumerable<T> entities);

        Task Delete(T entity);

        Task<IEnumerable<T>> All();

        Task<IEnumerable<T>> Where(Func<T,bool> predicate);

        Task<T> FirstOrDefault(Func<T, bool> predicate);
    }
}

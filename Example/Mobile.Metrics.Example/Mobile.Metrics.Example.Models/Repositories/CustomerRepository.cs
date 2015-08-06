using Mobile.Metrics.Example.Models.Entities;
using Mobile.Metrics.Example.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Metrics.Example.Models.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private List<Customer> entities = new List<Customer>();

        public Task<IEnumerable<Customer>> All()
        {
            return Async<IEnumerable<Customer>>.FromResult(this.entities);
        }

        public Task Delete(Customer entity)
        {
            this.entities.Remove(entity);
            return Async.Empty();
        }

        public Task<Customer> FirstOrDefault(Func<Customer, bool> predicate)
        {
            return Async<Customer>.FromResult(this.entities.FirstOrDefault(predicate));
        }

        public Task Insert(IEnumerable<Customer> entities)
        {
            this.entities.AddRange(entities);
            return Async.Empty();
        }

        public Task Insert(Customer entity)
        {
            this.entities.Add(entity);
            return Async.Empty();
        }

        public Task<IEnumerable<Customer>> Where(Func<Customer, bool> predicate)
        {
            return Async<IEnumerable<Customer>>.FromResult(this.entities.Where(predicate));
        }
    }
}

using Mobile.Metrics.Example.Models.Entities;
using Mobile.Metrics.Example.Models.Repositories;
using Mobile.Metrics.Example.Models.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile.Metrics.Example.Models.DataAccess
{
    public class CustomerDataAccess 
    {
        public CustomerDataAccess(IRepository<Customer> repository, IRestService service)
        {
            this.repository = repository;
            this.service = service;
        }

        private IRepository<Customer> repository;

        private IRestService service;

        #region GetCustomers

        private Task<IEnumerable<Customer>> getCustomersTask;

        public Task<IEnumerable<Customer>> GetCustomers()
        {
            if (this.getCustomersTask != null)
                return this.getCustomersTask;

            var result = GetCustomersInternal();
            this.getCustomersTask = result;
            result.ContinueWith((c) => this.getCustomersTask = null);
            return result;
        }

        public async Task<IEnumerable<Customer>> GetCustomersInternal()
        {
            var localEntities = await this.repository.All();

            if (localEntities.Count() == 0)
            {
                localEntities = await this.service.GetCustomers();
                await this.repository.Insert(localEntities);
            }

            return localEntities;
        }

        #endregion

        #region GetCustomer

        private Dictionary<int,Task<Customer>> getCustomerTask = new Dictionary<int, Task<Customer>>();

        public Task<Customer> GetCustomer(int id)
        {
            if (this.getCustomerTask.ContainsKey(id))
                return this.getCustomerTask[id];

            var result = GetCustomerInternal(id);
            this.getCustomerTask[id] = result;
            result.ContinueWith((c) => this.getCustomerTask.Remove(id));
            return result;
        }

        public async Task<Customer> GetCustomerInternal(int id)
        {
            var localEntity = await this.repository.FirstOrDefault((e) => e.Identifier == id);

            if (localEntity == null)
            {
                var customers = await this.service.GetCustomers();
                await this.repository.Insert(customers);
            }

            return await this.repository.FirstOrDefault((e) => e.Identifier == id);
        }

        #endregion
    }
}

using Mobile.Metrics.Example.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Metrics.Example.Models.Web
{
    public interface IRestService
    {
        Task<IEnumerable<Customer>> GetCustomers();
    }
}

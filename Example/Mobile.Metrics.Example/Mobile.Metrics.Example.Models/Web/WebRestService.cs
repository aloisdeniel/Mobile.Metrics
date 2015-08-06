using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile.Metrics.Example.Models.Entities;
using Mobile.Metrics.Example.Models.Helpers;

namespace Mobile.Metrics.Example.Models.Web
{
    public class WebRestService : IRestService
    {
        public Task<IEnumerable<Customer>> GetCustomers()
        {
            return Async<IEnumerable<Customer>>.FromResult(new List<Customer>
            {
                new Customer
                {
                    Identifier = 1,
                    Name= "Parks",
                    Contacts = new List<Contact>
                    {
                        new Contact
                        {
                            Firstname = "Guillaume",
                            Lastname = "Parks",
                            PhoneNumber = "+33(858)-5999577",
                        },
                        new Contact
                        {
                            Firstname = "Hervé",
                            Lastname = "Parks",
                            PhoneNumber = "+33(858)-5786598",
                        },
                        new Contact
                        {
                            Firstname = "Jean",
                            Lastname = "Parks",
                            PhoneNumber = "+33(858)-1234566",
                        },

                    }
                },
                new Customer
                {
                    Identifier = 2,
                    Name= "Ridgeway",
                    Contacts = new List<Contact>
                    {
                        new Contact
                        {
                            Firstname = "Jean-Claude",
                            Lastname = "Ridgeway",
                            PhoneNumber = "+33(454)-5556233",
                        },
                        new Contact
                        {
                            Firstname = "Nestor",
                            Lastname = "Ridgeway",
                            PhoneNumber = "+33(454)-5556211",
                        },

                    }
                },

            });

        }
    }
}

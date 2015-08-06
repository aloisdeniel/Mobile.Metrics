namespace Mobile.Metrics.Example.Models.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// A customer of the company.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Customer()
        {
            this.Contacts = new List<Contact>();
        }

        /// <summary>
        /// Name of the customer.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Unique identifier of the customer entity.
        /// </summary>
        public int Identifier { get; set; }

        /// <summary>
        /// People the customer that can be called.
        /// </summary>
        public IEnumerable<Contact> Contacts { get; set; }
    }
}

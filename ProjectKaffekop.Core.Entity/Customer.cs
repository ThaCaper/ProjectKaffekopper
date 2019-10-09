using System.Collections.Generic;

namespace ProjectKaffekop.Core.Entity
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }
        public CustomerType Type { get; set; }

        public List<Order> Orders { get; set; }
    }

    public class CustomerType
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public List<Customer> Customers { get; set; }
        }
    }

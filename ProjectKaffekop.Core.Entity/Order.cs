using System;
using System.Collections.Generic;

namespace ProjectKaffekop.Core.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public Customer Customer { get; set; }
        public List<OrderLine> OrderLines { get; set; }
    }
}
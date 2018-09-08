using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entity
{
    class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; } 
    }
}

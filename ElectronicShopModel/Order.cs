using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicShopModel
{
    public class Order
    {
        public int id { get; set; }
        public int customerId { get; set; }
        public int productId { get; set; }
        public DateTime createdDate { get; set; }
       

    }
}

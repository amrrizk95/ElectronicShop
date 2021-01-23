using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicShopModel
{
    public class Order
    {
        public int id { get; set; }
        [ForeignKey("customer")]
        public int customerId { get; set; }
        [ForeignKey("product")]
        public int productId { get; set; }
        public DateTime createdDate { get; set; }
        public double totalCost { get; set; }
        public int qty { get; set; }
        public virtual Customer customer { get; set; }
        public virtual Product product { get; set; }


    }
}

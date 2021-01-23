using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicShopModel
{
    public class Product
    {
        public int id { get; set; }
        public string nameAr { get; set; }
        public string nameEn { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public DateTime createdDate { get; set; }
        [ForeignKey("category")]
        public int categoryId { get; set; }
        public virtual Category category { get; set; }

   
    }
}

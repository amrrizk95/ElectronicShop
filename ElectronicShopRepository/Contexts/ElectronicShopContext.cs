
using ElectronicShopModel;
using ElectronicShopRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicShop.Repository.Contexts
{
    public class ElectronicShopContext: DbContext
    {
       
        public ElectronicShopContext():base()
        {

        }
        public IConfiguration Configuration { get; }
        public ElectronicShopContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(@"Server=.;Database=ElectronicShop;Trusted_Connection=True; MultipleActiveResultSets=true");
            }
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlServer(Configuration.ConnectionString("ElectronicShop"));
        //    base.OnConfiguring(optionsBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; } 
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<User> Users { get; set; }


    }
}

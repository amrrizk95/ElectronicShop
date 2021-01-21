
using ElectronicShop.Repository.Contexts;
using ElectronicShop.Repository.Repositories.Base;
using ElectronicShopModel;
using ElectronicShopRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicShopRepository.Repositories
{
    public class ProductRepository : RepositoryBase<Product, int>, IProductRepository
    {
        public ProductRepository(ElectronicShopContext dbContext) : base(dbContext)
        {
                
        }
    }
}

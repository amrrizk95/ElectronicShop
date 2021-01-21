

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
    public class CustomerRepository : RepositoryBase<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(ElectronicShopContext dbContext) : base(dbContext)
        {

        }
    }
}

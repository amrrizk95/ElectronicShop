
using ElectronicShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicShopRepository
{
    public interface ICustomerRepository : IRepository<Customer, int>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicShopRepository
{
   public interface IUnitOfWork:IDisposable
    {
        ICategoryRepository CategoryRepository  { get;  }
        ICustomerRepository CustomerRepository  { get;  }
        IOrderRepository OrderRepository  { get;  }
        IProductRepository ProductRepository  { get;  }
        IUserRepository UserRepository   { get; }

        void Complete();
    }
}

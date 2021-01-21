using ElectronicShopRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicShopBL.IBL
{
   public interface IBussinseContext: IDisposable
    {
        IUnitOfWork UnitOfWork { get; set; }
        ICategoryBL CategoryBL { get;  }
         ICustomerBL CustomerBL{ get; }
         IOrderBL OrderBL { get; }
         IProductBL ProductBL { get; }
         IUserBL UserBL { get; }
         void Complete();
    }
}

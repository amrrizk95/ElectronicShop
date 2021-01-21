using ElectronicShopModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ElectronicShopBL.IBL
{
  public  interface ICustomerBL : ICommonBL<Customer>
    {
        List<Customer> GetWithInclude(Expression<Func<Customer, bool>> predicate, params String[] paths);

    }
}

using ElectronicShopModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ElectronicShopBL.IBL
{
   public interface IOrderBL : ICommonBL<Order>
    {
        List<Order> GetWithInclude(Expression<Func<Order, bool>> predicate, params String[] paths);

    }
}

using ElectronicShopModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ElectronicShopBL.IBL
{
   public interface IProductBL : ICommonBL<Product>
    {
        List<Product> GetWithInclude(Expression<Func<Product, bool>> predicate, params String[] paths);

    }
}

using ElectronicShopModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ElectronicShopBL.IBL
{
   public interface ICategoryBL : ICommonBL<Category>
    {
        List<Category> GetWithInclude(Expression<Func<Category, bool>> predicate, params String[] paths);
    }
}

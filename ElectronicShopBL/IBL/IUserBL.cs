using ElectronicShopModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ElectronicShopBL.IBL
{
   public interface IUserBL : ICommonBL<User>
    {
        List<User> GetWithInclude(Expression<Func<User, bool>> predicate, params String[] paths);

    }
}

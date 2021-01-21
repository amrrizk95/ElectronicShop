using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ElectronicShopBL.IBL
{
    public interface ICommonBL<Entity>
    {

        IBussinseContext BussinseContext { get; set; }
        void AddNew(Entity entity);
        List<Entity> GetAll(params String[] RelatedFields);
        List<Entity> GetAll();
        List<Entity> Search(string cretria);
        Entity Delete(int id);
        void Edit(Entity entity);
        Entity Get(int id);
        List<Entity> Check(Expression<Func<Entity, bool>> predicate);
    
    }
}

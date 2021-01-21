using ElectronicShopBL.IBL;
using ElectronicShopModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ElectronicShopBL.BL
{
   public class OrderBL: IOrderBL
    {
        public IBussinseContext BussinseContext { get; set; }
        public OrderBL(IBussinseContext bussinseContext)
        {
            BussinseContext = bussinseContext;
        }

        public void AddNew(Order entity)
        {
            BussinseContext.UnitOfWork.OrderRepository.Add(entity);
            BussinseContext.UnitOfWork.Complete();

        }

        public Order Delete(int id)
        {
            Order Order = BussinseContext.UnitOfWork.OrderRepository.Get(id);
            try
            {
                if (Order != null)
                {
                    BussinseContext.UnitOfWork.OrderRepository.Remove(Order);
                }
                else
                {
                    throw new Exception("Not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Order;

        }

        public void Edit(Order entity)
        {
            BussinseContext.UnitOfWork.OrderRepository.Update(entity);
        }

        public Order Get(int id)
        {
            return BussinseContext.UnitOfWork.OrderRepository.Get(id);
        }

        public List<Order> GetAll(params string[] RelatedFields)
        {
            return BussinseContext.UnitOfWork.OrderRepository.GetAllWithInclude(RelatedFields);

        }
        public List<Order> GetAll()
        {
            return BussinseContext.UnitOfWork.OrderRepository.GetAll();
        }

        public List<Order> Search(string cretria)
        {
            throw new NotImplementedException();
        }
        public Order GetWithInclude(int id, params String[] paths)
        {
            return BussinseContext.UnitOfWork.OrderRepository.GetWithInclude(id, paths);
        }

        public List<Order> Check(Expression<Func<Order, bool>> predicate)
        {
            return BussinseContext.UnitOfWork.OrderRepository.Find(predicate);
        }
        public List<Order> GetAll(Expression<Func<Order, bool>> predicate)
        {
            return BussinseContext.UnitOfWork.OrderRepository.GetAll(predicate);

        }

        public List<Order> GetWithInclude(Expression<Func<Order, bool>> predicate, params string[] paths)
        {
            return BussinseContext.UnitOfWork.OrderRepository.GetWithInclude(predicate, paths);

        }
    }
}

using ElectronicShopBL.IBL;
using ElectronicShopModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ElectronicShopBL.BL
{
   public class CustomerBL: ICustomerBL
    {
        public IBussinseContext BussinseContext { get; set; }
        public CustomerBL(IBussinseContext bussinseContext)
        {
            BussinseContext = bussinseContext;
        }

        public void AddNew(Customer entity)
        {
            BussinseContext.UnitOfWork.CustomerRepository.Add(entity);
            BussinseContext.UnitOfWork.Complete();

        }

        public Customer Delete(int id)
        {
            Customer Customer = BussinseContext.UnitOfWork.CustomerRepository.Get(id);
            try
            {
                if (Customer != null)
                {
                    BussinseContext.UnitOfWork.CustomerRepository.Remove(Customer);
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
            return Customer;

        }

        public void Edit(Customer entity)
        {
            BussinseContext.UnitOfWork.CustomerRepository.Update(entity);
        }

        public Customer Get(int id)
        {
            return BussinseContext.UnitOfWork.CustomerRepository.Get(id);
        }

        public List<Customer> GetAll(params string[] RelatedFields)
        {
            return BussinseContext.UnitOfWork.CustomerRepository.GetAllWithInclude(RelatedFields);

        }
        public List<Customer> GetAll()
        {
            return BussinseContext.UnitOfWork.CustomerRepository.GetAll();
        }

        public List<Customer> Search(string cretria)
        {
            throw new NotImplementedException();
        }
        public Customer GetWithInclude(int id, params String[] paths)
        {
            return BussinseContext.UnitOfWork.CustomerRepository.GetWithInclude(id, paths);
        }

        public List<Customer> Check(Expression<Func<Customer, bool>> predicate)
        {
            return BussinseContext.UnitOfWork.CustomerRepository.Find(predicate);
        }
        public List<Customer> GetAll(Expression<Func<Customer, bool>> predicate)
        {
            return BussinseContext.UnitOfWork.CustomerRepository.GetAll(predicate);

        }

        public List<Customer> GetWithInclude(Expression<Func<Customer, bool>> predicate, params string[] paths)
        {
            return BussinseContext.UnitOfWork.CustomerRepository.GetWithInclude(predicate, paths);

        }
    }
}

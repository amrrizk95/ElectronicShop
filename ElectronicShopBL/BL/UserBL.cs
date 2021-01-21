using ElectronicShopBL.IBL;
using ElectronicShopModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ElectronicShopBL.BL
{
   public class UserBL: IUserBL
    {
        public IBussinseContext BussinseContext { get; set; }
        public UserBL(IBussinseContext bussinseContext)
        {
            BussinseContext = bussinseContext;
        }

        public void AddNew(User entity)
        {
            BussinseContext.UnitOfWork.UserRepository.Add(entity);
            BussinseContext.UnitOfWork.Complete();

        }

        public User Delete(int id)
        {
            User User = BussinseContext.UnitOfWork.UserRepository.Get(id);
            try
            {
                if (User != null)
                {
                    BussinseContext.UnitOfWork.UserRepository.Remove(User);
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
            return User;

        }

        public void Edit(User entity)
        {
            BussinseContext.UnitOfWork.UserRepository.Update(entity);
        }

        public User Get(int id)
        {
            return BussinseContext.UnitOfWork.UserRepository.Get(id);
        }

        public List<User> GetAll(params string[] RelatedFields)
        {
            return BussinseContext.UnitOfWork.UserRepository.GetAllWithInclude(RelatedFields);

        }
        public List<User> GetAll()
        {
            return BussinseContext.UnitOfWork.UserRepository.GetAll();
        }

        public List<User> Search(string cretria)
        {
            throw new NotImplementedException();
        }
        public User GetWithInclude(int id, params String[] paths)
        {
            return BussinseContext.UnitOfWork.UserRepository.GetWithInclude(id, paths);
        }

        public List<User> Check(Expression<Func<User, bool>> predicate)
        {
            return BussinseContext.UnitOfWork.UserRepository.Find(predicate);
        }
        public List<User> GetAll(Expression<Func<User, bool>> predicate)
        {
            return BussinseContext.UnitOfWork.UserRepository.GetAll(predicate);

        }

        public List<User> GetWithInclude(Expression<Func<User, bool>> predicate, params string[] paths)
        {
            return BussinseContext.UnitOfWork.UserRepository.GetWithInclude(predicate, paths);

        }
    }
}

using ElectronicShopBL.IBL;
using ElectronicShopModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ElectronicShopBL.BL
{
   public class CategoryBL: ICategoryBL
    {
        public IBussinseContext BussinseContext { get; set; }
        public CategoryBL(IBussinseContext bussinseContext)
        {
            BussinseContext = bussinseContext;
        }

        public void AddNew(Category entity)
        {
            BussinseContext.UnitOfWork.CategoryRepository.Add(entity);
            BussinseContext.UnitOfWork.Complete();

        }

        public Category Delete(int id)
        {
            Category Category = BussinseContext.UnitOfWork.CategoryRepository.Get(id);
            try
            {
                if (Category != null)
                {
                    BussinseContext.UnitOfWork.CategoryRepository.Remove(Category);
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
            return Category;

        }

        public void Edit(Category entity)
        {
            BussinseContext.UnitOfWork.CategoryRepository.Update(entity);
        }

        public Category Get(int id)
        {
            return BussinseContext.UnitOfWork.CategoryRepository.Get(id);
        }

        public List<Category> GetAll(params string[] RelatedFields)
        {
            return BussinseContext.UnitOfWork.CategoryRepository.GetAllWithInclude(RelatedFields);

        }
        public List<Category> GetAll()
        {
            return BussinseContext.UnitOfWork.CategoryRepository.GetAll();
        }

        public List<Category> Search(string cretria)
        {
            throw new NotImplementedException();
        }
        public Category GetWithInclude(int id, params String[] paths)
        {
            return BussinseContext.UnitOfWork.CategoryRepository.GetWithInclude(id, paths);
        }

        public List<Category> Check(Expression<Func<Category, bool>> predicate)
        {
            return BussinseContext.UnitOfWork.CategoryRepository.Find(predicate);
        }
        public List<Category> GetAll(Expression<Func<Category, bool>> predicate)
        {
            return BussinseContext.UnitOfWork.CategoryRepository.GetAll(predicate);

        }

        public List<Category> GetWithInclude(Expression<Func<Category, bool>> predicate, params string[] paths)
        {
            return BussinseContext.UnitOfWork.CategoryRepository.GetWithInclude(predicate, paths);

        }
    }
}

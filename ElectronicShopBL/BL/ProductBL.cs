using ElectronicShopBL.IBL;
using ElectronicShopModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ElectronicShopBL.BL
{
   public class ProductBL: IProductBL
    {
        public IBussinseContext BussinseContext { get; set; }
        public ProductBL(IBussinseContext bussinseContext)
        {
            BussinseContext = bussinseContext;
        }

        public void AddNew(Product entity)
        {
            BussinseContext.UnitOfWork.ProductRepository.Add(entity);
            BussinseContext.UnitOfWork.Complete();

        }

        public Product Delete(int id)
        {
            Product Product = BussinseContext.UnitOfWork.ProductRepository.Get(id);
            try
            {
                if (Product != null)
                {
                    BussinseContext.UnitOfWork.ProductRepository.Remove(Product);
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
            return Product;

        }

        public void Edit(Product entity)
        {
            BussinseContext.UnitOfWork.ProductRepository.Update(entity);
        }

        public Product Get(int id)
        {
            return BussinseContext.UnitOfWork.ProductRepository.Get(id);
        }

        public List<Product> GetAll(params string[] RelatedFields)
        {
            return BussinseContext.UnitOfWork.ProductRepository.GetAllWithInclude(RelatedFields);

        }
        public List<Product> GetAll()
        {
            return BussinseContext.UnitOfWork.ProductRepository.GetAll();
        }

        public List<Product> Search(string cretria)
        {
            throw new NotImplementedException();
        }
        public Product GetWithInclude(int id, params String[] paths)
        {
            return BussinseContext.UnitOfWork.ProductRepository.GetWithInclude(id, paths);
        }

        public List<Product> Check(Expression<Func<Product, bool>> predicate)
        {
            return BussinseContext.UnitOfWork.ProductRepository.Find(predicate);
        }
        public List<Product> GetAll(Expression<Func<Product, bool>> predicate)
        {
            return BussinseContext.UnitOfWork.ProductRepository.GetAll(predicate);

        }

        public List<Product> GetWithInclude(Expression<Func<Product, bool>> predicate, params string[] paths)
        {
            return BussinseContext.UnitOfWork.ProductRepository.GetWithInclude(predicate, paths);

        }
    }
}

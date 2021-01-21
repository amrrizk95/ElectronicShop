using ElectronicShop.Repository.Contexts;
using ElectronicShopRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicShopRepository.Repositories
{
  public  class UnitOfWork : IUnitOfWork
    {
        private readonly ElectronicShopContext _dbContext;
        public UnitOfWork(ElectronicShopContext dbContext)
        {
            _dbContext = dbContext;
        }
         ICategoryRepository categoryRepository ;

         ICustomerRepository customerRepository ;

         IOrderRepository orderRepository;

         IProductRepository productRepository ;

         IUserRepository userRepository;


        public ICategoryRepository CategoryRepository {
            get
            {
                if (categoryRepository == null)
                    return new CategoryRepository(_dbContext);
                else
                    return categoryRepository;
            }
        }

        public ICustomerRepository CustomerRepository 
        {
           get
            {
                    if (customerRepository == null)
                        return new CustomerRepository(_dbContext);
                    else
                        return customerRepository;
            }
            
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                if (orderRepository == null)
                    return new OrderRepository(_dbContext);
                else
                    return orderRepository;
            }

        }

        public IProductRepository ProductRepository
        {
            get
            {
                if (productRepository == null)
                    return new ProductRepository(_dbContext);
                else
                    return productRepository;
            }
        }

        public IUserRepository UserRepository {
            get
            {
                if (userRepository == null)
                    return new UserRepository(_dbContext);
                else
                    return userRepository;
            }
        }


        public void Dispose()
        {
            _dbContext.Dispose();
        }
        public void Complete()
        {
            _dbContext.SaveChanges();
        }
    }
}

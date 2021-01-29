using ElectronicShopBL.IBL;
using ElectronicShopRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Text;
using Unity;
using Unity.Resolution;

namespace ElectronicShopBL.BL
{
   public class BussinseContext : IBussinseContext
    {


        IUnitOfWork unitOfWork;
        ICategoryBL categoryBL;
        ICustomerBL customerBL;
        IOrderBL orderBL;
        IProductBL productBL;
        IUserBL userBL;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                if (unitOfWork == null)
                {
                    unitOfWork = UnityConfig.Container.Resolve<IUnitOfWork>(new ResolverOverride[]
                        {
                              new ParameterOverride("bussinseContext", this)
                        });
                }
                return unitOfWork;
            }
        }
        public ICategoryBL CategoryBL
        {
            get
            {
                if (categoryBL == null)
                {
                    categoryBL = UnityConfig.Container.Resolve<ICategoryBL>(new ResolverOverride[]
                          {
                              new ParameterOverride("bussinseContext", this)
                          });
                }

                return categoryBL;
            }
        }
        public ICustomerBL CustomerBL
        {
            get
            {
                if (customerBL == null)
                {
                    customerBL = UnityConfig.Container.Resolve<ICustomerBL>(new ResolverOverride[]
                          {
                              new ParameterOverride("bussinseContext", this)
                          });
                }

                return customerBL;
            }
        }
        public IOrderBL OrderBL
        {
            get
            {
                if (orderBL == null)
                {
                    orderBL = UnityConfig.Container.Resolve<IOrderBL>(new ResolverOverride[]
                          {
                              new ParameterOverride("bussinseContext", this)
                          });
                }

                return orderBL;
            }
        }
        public IProductBL ProductBL
        {
            get
            {
                if (productBL == null)
                {
                    productBL = UnityConfig.Container.Resolve<IProductBL>(new ResolverOverride[]
                          {
                              new ParameterOverride("bussinseContext", this)
                          });
                }

                return productBL;
            }
        } 


  
        public IUserBL UserBL
        {
            get
            {
                if (userBL == null)
                {
                    userBL = UnityConfig.Container.Resolve<IUserBL>(new ResolverOverride[]
                          {
                              new ParameterOverride("bussinseContext", this)
                          });
                }

                return userBL;
            }
        }
        public void Complete()
        {
            try
            {
                UnitOfWork.Complete();
            }

            catch (Exception e)
            {
               
                throw new Exception(e.Message);
                // we can add message quee layer to desplay frindly  message to user
                throw;
            }
        }
        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}

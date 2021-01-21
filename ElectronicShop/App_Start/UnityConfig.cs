using ElectronicShopBL.BL;
using ElectronicShopBL.IBL;
using ElectronicShopRepository;
using ElectronicShopRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity;

namespace ElectronicShop.App_Start
{
    public static class UnityConfig
    {
        public static UnityContainer Container { get; set; }
        public static void RegisterComponents()
        {
            Container = new UnityContainer();
            Container.RegisterType<IUnitOfWork, UnitOfWork>();

           
            Container.RegisterType<ICategoryBL, CategoryBL>();
            Container.RegisterType<IBussinseContext, BussinseContext>();
            Container.RegisterType<ICustomerBL, CustomerBL>();
            Container.RegisterType<IOrderBL, OrderBL>();
            Container.RegisterType<IProductBL, ProductBL>();
            Container.RegisterType<IUserBL, UserBL>();

            ElectronicShopBL.UnityConfig.Container = Container;

        }
    }
}

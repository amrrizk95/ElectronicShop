using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace ElectronicShopBL
{
  public static  class UnityConfig
    {
        public static UnityContainer Container { get; set; }
        public static void RegisterComponents()
        {
            if (Container == null)
                Container = new UnityContainer();
        }
    }
}

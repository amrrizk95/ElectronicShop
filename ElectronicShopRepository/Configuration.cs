using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ElectronicShopRepository
{
  public static  class Configuration
    {
        public static IConfigurationRoot GetConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            return builder.Build();
        }

        public static string ConnectionString(string name)
        {

            return GetConfig().GetConnectionString(name);

        }
    }
}

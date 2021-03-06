using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace V6Shop.Data.EF
{
    class V6ShopDBContextFactory : IDesignTimeDbContextFactory<V6ShopDBContext>
    {
        public V6ShopDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();
            var connectionString = configuration.GetConnectionString("V6shopDB");

            var optionsBuilder = new DbContextOptionsBuilder<V6ShopDBContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new V6ShopDBContext(optionsBuilder.Options);
        }
    }
}

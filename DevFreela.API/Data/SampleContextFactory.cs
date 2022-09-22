using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DevFreela.API.Data
{
    public class SampleContextFactory : IDesignTimeDbContextFactory<DevFreelaDbContext>
    {
        public DevFreelaDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<DevFreelaDbContext>();
            var connectionString = configuration.GetConnectionString("DevFreelaCs");
            builder.UseSqlServer(connectionString, b => b.MigrationsAssembly("DevFreela.API"));

            return new DevFreelaDbContext(builder.Options);
        }
    }
}

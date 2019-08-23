using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ConFusion.Data
{
    public class ConFusionContextFactory : IDesignTimeDbContextFactory<ConFusionContext>
    {
        public ConFusionContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            return new ConFusionContext(new DbContextOptionsBuilder<ConFusionContext>().Options, config);
        }
    }
}

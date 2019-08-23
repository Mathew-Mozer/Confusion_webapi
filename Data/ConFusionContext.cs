using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ConFusion.Data
{
    public class ConFusionContext : DbContext
    {
        private readonly IConfiguration config;

        //These are the objects that will manipulate the database
        public DbSet<Dishes> Dishes { get; set; }
        public DbSet<Leaders> Leaders { get; set; }
        public DbSet<Promotions> Promotions { get; set; }
        public DbSet<Comments> Comments { get; set; }

        public ConFusionContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            this.config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("ConFusion"));
        }
    }
}

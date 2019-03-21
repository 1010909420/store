using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
    public class StoreDbContext : DbContext
    {
        public DbSet<T_User> T_User { get; set; }
        public DbSet<T_Addr> T_Addr { get; set; }
        public DbSet<T_Goods> T_Goods { get; set; }
        public DbSet<T_Comment> T_Comment { get; set; }
        public DbSet<T_ShoppingCart> T_ShoppingCart { get; set; }
        public DbSet<T_Order> T_Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("sql.json");
            var configuration = builder.Build();

            string connStr = configuration["ConnectionString"];
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(connStr);
            }
        }

    }
}

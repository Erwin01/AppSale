using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using App.Sale.Domain;
using App.Sale.Infraestructure.Data.Configs;

namespace App.Sale.Infraestructure.Data.Contexts
{
    public class SaleContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=VentasDb;User=Administrador;Password=123456");
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new SaleConfig());
            modelBuilder.ApplyConfiguration(new SaleDetailConfig());

        }
    }
}

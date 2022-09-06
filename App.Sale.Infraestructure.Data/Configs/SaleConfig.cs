using App.Sale.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Sale.Infraestructure.Data.Configs
{
    public class SaleConfig : IEntityTypeConfiguration<Sales>
    {

        public void Configure(EntityTypeBuilder<Sales> builder)
        {
            builder.ToTable("Sales");
            builder.HasKey(s => s.SaleId);

            builder
                .HasMany(sale => sale.SaleDetails)
                .WithOne(detail => detail.Sale);
        }
    }
}

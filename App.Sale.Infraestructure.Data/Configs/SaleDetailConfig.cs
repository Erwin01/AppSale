using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App.Sale.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Sale.Infraestructure.Data.Configs
{
    public class SaleDetailConfig : IEntityTypeConfiguration<SaleDetail>
    {
        public void Configure(EntityTypeBuilder<SaleDetail> builder)
        {
            builder.ToTable("SalesDetails");
            builder.HasKey(saleDetail => new { saleDetail.ProductId, saleDetail.SaleId });

            builder
                .HasOne(detail => detail.Producto)
                .WithMany(product => product.SaleDetails);

            builder
                .HasOne(detail => detail.Sale)
                .WithMany(sale => sale.SaleDetails);
        }
    }
}

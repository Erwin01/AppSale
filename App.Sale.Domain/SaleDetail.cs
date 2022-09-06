using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Sale.Domain
{
    public class SaleDetail
    {

        public Guid ProductId { get; set; }
        public Guid SaleId { get; set; }
        public decimal CostUnit { get; set; }
        public decimal PriceUnit { get; set; }
        public decimal QuantitySale { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }

        public Product Producto { get; set; }
        public Sales Sale { get; set; }


    }
}

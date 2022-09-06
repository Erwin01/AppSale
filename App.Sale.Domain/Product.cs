using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Sale.Domain
{
    public class Product
    {

        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal QuantityInStock { get; set; }

        public List<SaleDetail> SaleDetails { get; set; }

    }
}

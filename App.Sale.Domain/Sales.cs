using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Sale.Domain
{
    public class Sales
    {

        public Guid SaleId { get; set; }
        public long SaleNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Concept { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public bool Cancel { get; set; } = false;


        public List<SaleDetail> SaleDetails { get; set; }
    }
}

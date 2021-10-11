using System;
using System.Collections.Generic;

namespace WebSales.Models
{
    public partial class Sales
    {
        public int IdSale { get; set; }
        public DateTime DateSale { get; set; }
        public int IdSupplier { get; set; }
        public int IdProduct { get; set; }

        public virtual Products IdProductNavigation { get; set; }
        public virtual Suppliers IdSupplierNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace WebSales.Models
{
    public partial class Suppliers
    {
        public Suppliers()
        {
            Sales = new HashSet<Sales>();
        }

        public int IdSupplier { get; set; }
        public string SupplierName { get; set; }
        public string SupplierDescription { get; set; }
        public string SupplierWebSite { get; set; }
        public string SupplierAddress { get; set; }

        public virtual ICollection<Sales> Sales { get; set; }
    }
}

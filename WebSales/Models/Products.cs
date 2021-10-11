using System;
using System.Collections.Generic;

namespace WebSales.Models
{
    public partial class Products
    {
        public Products()
        {
            Sales = new HashSet<Sales>();
        }

        public int IdProduct { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        public virtual ICollection<Sales> Sales { get; set; }
    }
}

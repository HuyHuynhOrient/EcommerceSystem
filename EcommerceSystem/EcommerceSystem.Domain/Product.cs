using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.Domain
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ProductNumber { get; set; }
        public string TradeMark { get; set; }
        public string Origin { get; set; }
        public string Discription { get; set; }
        public int ProductSubcategoryID { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}

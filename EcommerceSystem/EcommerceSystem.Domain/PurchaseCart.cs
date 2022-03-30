using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.Domain
{
    public class PurchaseCart
    {
        public int PurchaseCartID { get; set; }
        public int CustonmerID { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}

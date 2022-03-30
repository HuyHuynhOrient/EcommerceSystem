using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.Domain
{
    public class PurchaseOrder
    {
        public int PurchaseCartID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ShippedDated { get; set; }
        public string ShipAdress { get; set; }
        public string ShipPhoneNumber { get; set; }
        public int ShippingUnitID { get; set; }
        public int ShippingStatusID { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.Domain
{
    public class ShippingUnit
    {
        public int ShippingUnitID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}

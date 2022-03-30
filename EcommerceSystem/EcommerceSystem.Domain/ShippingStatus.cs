using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.Domain
{
    public class ShippingStatus
    {
        public int ShippingStatusID { get; set; }
        public string Status { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}

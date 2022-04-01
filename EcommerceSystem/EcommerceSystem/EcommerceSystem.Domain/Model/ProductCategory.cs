using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.Domain.Model
{
    public class ProductCategory
    {
        [Key]
        public int ProductCategoryID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }
    }
}

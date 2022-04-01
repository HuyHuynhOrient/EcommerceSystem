using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.Domain.Entities
{
    [Table("Product")]
    public class ProductEntity : Domain.Model.Product
    {
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }
        // Relationships
        [ForeignKey("ProductSubcategoryID")]
        public ProductSubcategoryEntity ProductSubcategory { get; set; }
    }
}

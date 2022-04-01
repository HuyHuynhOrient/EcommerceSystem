using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.Domain.Entities
{
    [Table("ProductCategory")]
    public class ProductCategoryEntity : Domain.Model.ProductCategory
    {
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }
        // Relationships
        List<ProductSubcategoryEntity> ProductSubcategories { get; set; }
    }
}

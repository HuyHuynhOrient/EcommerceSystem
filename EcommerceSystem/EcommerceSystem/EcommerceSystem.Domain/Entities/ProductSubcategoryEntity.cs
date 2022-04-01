using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.Domain.Entities
{
    [Table("ProductSubcategory")]
    public class ProductSubcategoryEntity : Domain.Model.ProductSubcategory
    {
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }
        // Relationships
        [ForeignKey("ProductCategoryID")]
        public ProductCategoryEntity ProductCategory { get; set; }
        public List<ProductEntity> Products { get; set; }
    }
}

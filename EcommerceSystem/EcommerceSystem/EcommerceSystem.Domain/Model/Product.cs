using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.Domain.Model
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,0)")]
        public decimal Price { get; set; }

        [Required]
        public int ProductNumber { get; set; }

        [StringLength(100)]
        public string? TradeMark { get; set; }

        [StringLength(100)]
        public string? Origin { get; set; }

        [StringLength(1024)]
        public string? Discription { get; set; }
        public int ProductSubcategoryID { get; set; }
    }
}

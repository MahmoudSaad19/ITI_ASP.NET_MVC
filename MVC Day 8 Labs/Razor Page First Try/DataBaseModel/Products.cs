using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Razor_Page_First_Try.DataBaseModel
{
    public partial class Products
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }
        public int? Units { get; set; }
        public int? Price { get; set; }
        [Column("SupplierID")]
        public int? SupplierId { get; set; }

        [ForeignKey(nameof(SupplierId))]
        [InverseProperty("Products")]
        public virtual Supplier Supplier { get; set; }
    }
}

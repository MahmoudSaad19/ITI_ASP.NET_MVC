using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Razor_Page_First_Try.DataBaseModel
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Products>();
        }

        [Key]
        [Column("SupID")]
        public int SupId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string City { get; set; }

        [InverseProperty("Supplier")]
        public virtual ICollection<Products> Products { get; set; }
    }
}

namespace Single_Page_App.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        public int? Units { get; set; }

        public int? Price { get; set; }

        public int? SupplierID { get; set; }
    }
}

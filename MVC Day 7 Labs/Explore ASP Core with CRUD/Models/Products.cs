﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Explore_ASP_Core_with_CRUD.Models
{
    public partial class Products
    {
        public int Id { get; set; }

        //[Required]
        public string ProductName { get; set; }
        public int? Units { get; set; }
        public int? Price { get; set; }
        public int? SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}

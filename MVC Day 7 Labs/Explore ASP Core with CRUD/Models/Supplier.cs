using System;
using System.Collections.Generic;

namespace Explore_ASP_Core_with_CRUD.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Products>();
        }

        public int SupId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}

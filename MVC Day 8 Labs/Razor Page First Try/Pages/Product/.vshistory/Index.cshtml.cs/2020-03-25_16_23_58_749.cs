using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Razor_Page_First_Try.DataBaseModel;

namespace Razor_Page_First_Try.Pages.Product
{
    public class IndexModel : PageModel
    {
        MVC_ProductsContext dbContext;
            
        public IEnumerable<Products> MyProducts { get; set; }
        public IEnumerable<Supplier> AllSuppliers { get; set; }
        [BindProperty]
        public Products product { get; set; }

        public IndexModel(MVC_ProductsContext context)
        {
            dbContext = context;
        }

        public void OnGet()
        {
            ViewData["sups"] = new SelectList(dbContext.Supplier,"SupId","Name","SupplierID");
            MyProducts = dbContext.Products.Include(p=>p.Supplier);
        }

        public IActionResult OnPostAdd(Products product)
        {
            if (ModelState.IsValid)
            {
                dbContext.Products.Add(product);
                dbContext.SaveChanges();               
            }
            return RedirectToPage("index");
        }

        //[HttpGet]
        //public IActionResult edit(int? id)
        //{
        //    Products product = dbContext.Products.Find(id);
        //    if (product == null)
        //    {
        //        return View("_ErrorView");
        //    }
        //    return PartialView(product);
        //}

        public IActionResult OnPostEdit(int id, Products product)
        {
            if (ModelState.IsValid)
            {
                Products updatedproduct = dbContext.Products.Find(id);
                updatedproduct.ProductName = product.ProductName;
                updatedproduct.Price = product.Price;
                updatedproduct.Units = product.Units;
                updatedproduct.SupplierId = product.SupplierId;
                dbContext.SaveChanges();
            }
            return RedirectToPage("index");
        }

        public IActionResult OnPostDelete(int? id)
        {
            Products product = dbContext.Products.Find(id);
            if (product == null)
            {
                return RedirectToPage("Error");
            }
            dbContext.Products.Remove(product);
            dbContext.SaveChanges();
            return RedirectToPage("index");
        }
    }

    public class MiddleDataBaseModel
    {
        public int PId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public int? Units { get; set; }
        public int? Price { get; set; }
        public int? SId { get; set; }

    }
}
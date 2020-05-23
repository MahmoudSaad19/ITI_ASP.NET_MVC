using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_Page_First_Try.DataBaseModel;

namespace Razor_Page_First_Try.Pages.Product
{
    public class IndexModel : PageModel
    {
        MVC_ProductsContext dbContext;

        public IndexModel(MVC_ProductsContext context)
        {
            dbContext = context;
        }

        public void OnGet()
        {

        }

        public IActionResult Index()
        {
            return View(dbContext.Products.ToList());
        }

        [HttpGet]
        public IActionResult add()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult add(Products product)
        {
            if (ModelState.IsValid)
            {
                dbContext.Products.Add(product);
                dbContext.SaveChanges();
                return RedirectToAction("index");
            }

            return View(product);
        }

        [HttpGet]
        public IActionResult edit(int? id)
        {
            Products product = dbContext.Products.Find(id);
            if (product == null)
            {
                return View("_ErrorView");
            }
            return PartialView(product);
        }

        [HttpPost]
        public IActionResult edit(int id, Products product)
        {
            if (ModelState.IsValid)
            {
                Products updatedproduct = dbContext.Products.Find(id);
                updatedproduct.ProductName = product.ProductName;
                updatedproduct.Price = product.Price;
                updatedproduct.Units = product.Units;
                dbContext.SaveChanges();
                return RedirectToAction("index");
            }
            return View(product);
        }

        public IActionResult delete(int? id)
        {
            Products product = dbContext.Products.Find(id);
            if (product == null)
            {
                return View("_ErrorView");
            }
            dbContext.Products.Remove(product);
            dbContext.SaveChanges();
            return RedirectToAction("index");
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
        //public int? SId { get; set; }
       
    }
}
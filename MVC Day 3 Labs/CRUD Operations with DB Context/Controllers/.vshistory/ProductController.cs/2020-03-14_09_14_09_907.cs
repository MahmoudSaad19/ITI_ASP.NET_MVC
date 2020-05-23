using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_Operations_with_DB_Context.Models;

namespace CRUD_Operations_with_DB_Context.Controllers
{
    public class ProductController : Controller
    {
        ContextManager contextManager = new ContextManager();

        public ActionResult Home()
        {
            return View();
        }
                
        public ActionResult DisplayAll()
        {
            return View(contextManager.Products.ToList());
        }

        [HttpGet]
        public ActionResult Insert()
        {
            ViewBag.SupplierID = new SelectList(contextManager.Suppliers, "SupID", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Product product)
        {
            if (ModelState.IsValid)
            {
                contextManager.Products.Add(product);
                contextManager.SaveChanges();
                return RedirectToAction("DisplayAll");
            }
            ViewBag.SupplierID = new SelectList(contextManager.Suppliers, "SupID", "Name");
            return View();
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            Product product = contextManager.Products.FirstOrDefault(p => p.ID == id);
            if (product != null)
            {
                ViewBag.SupplierID = new SelectList(contextManager.Suppliers, "SupID", "Name", product.SupplierID);
                return View(product);
            }
            return View("_error");
        }

        [HttpPost]
        public ActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                var prd = contextManager.Products.Find(product.ID);
                prd.ProductName = product.ProductName;
                prd.Price = product.Price;
                prd.Units = product.Units;
                prd.SupplierID = product.SupplierID;
                contextManager.SaveChanges();
                return RedirectToAction("DisplayAll");
            }
            ViewBag.SupplierID = new SelectList(contextManager.Suppliers, "SupID", "Name");
            return View();
        }

        public ActionResult Delete(int? id)
        {
            var prd = contextManager.Products.Find(id);
            if (prd != null)
            {
                contextManager.Products.Remove(prd);
                contextManager.SaveChanges();
                return RedirectToAction("DisplayAll");
            }
            return View("_error");
        }

        public ActionResult top3()
        {
            var topProducts = contextManager.Products.OrderByDescending(p => p.Units).Take(3);
            return PartialView(topProducts);
        }
    }
}
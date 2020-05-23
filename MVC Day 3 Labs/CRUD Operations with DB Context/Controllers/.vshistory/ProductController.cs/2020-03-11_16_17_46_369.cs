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

        public ActionResult DisplayAll()
        {
            return View(contextManager.Products.ToList());
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Product product)
        {
            if (ModelState.IsValid)
            {
                contextManager.Products.Add(product);
                return RedirectToAction("DisplayAll");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {

            return View();
        }

        [HttpPost]
        public ActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                var prd = contextManager.Suppliers.Find(product.SupID);
                prd.Name = product.Name;
                prd.City = product.City;
                return RedirectToAction("DisplayAll");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var sup = contextManager.Suppliers.Find(id);
            contextManager.Suppliers.Remove(sup);
            return RedirectToAction("DisplayAll");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Single_Page_App.Models;

namespace Single_Page_App.Controllers
{
    public class ProductsController : Controller
    {
        private DataBaseContextManager db = new DataBaseContextManager();

        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        // GET: Products
        public ActionResult DisplayAll()
        {
            return PartialView(db.Products.OrderByDescending(p => p.ID).ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("_ErrorView");
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return PartialView();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductName,Units,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return PartialView("DisplayAll", db.Products.OrderByDescending(p => p.ID).ToList());
            }
            return PartialView(product);
        }

        
        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {            
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return PartialView();
            }
            return PartialView(product);
        }
        
        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProductName,Units,Price,SupplierID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return PartialView("DisplayAll", db.Products.OrderByDescending(p => p.ID).ToList());
            }
            return PartialView(product);
        }
        

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {            
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View("DeleteConfirmed");
        }

        //POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

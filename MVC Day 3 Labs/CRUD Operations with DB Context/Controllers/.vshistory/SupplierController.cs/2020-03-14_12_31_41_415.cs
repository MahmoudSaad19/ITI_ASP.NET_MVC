using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_Operations_with_DB_Context.Models;

namespace CRUD_Operations_with_DB_Context.Controllers
{
    public class SupplierController : Controller
    {
        ContextManager contextManager = new ContextManager();

            public ActionResult DisplayAll()
        {
            return View(contextManager.Suppliers.ToList());
        }

        [HttpGet]
        public ActionResult Insert()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                contextManager.Suppliers.Add(supplier);
                contextManager.SaveChanges();
                return RedirectToAction("DisplayAll");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            Supplier supplier = contextManager.Suppliers.Find(id);
            if (supplier != null)
            {
                return View(supplier);
            }
            return View("_error");
        }

        [HttpPost]
        public ActionResult Update(int id , Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                var sup = contextManager.Suppliers.Find(id);
                sup.Name = supplier.Name;
                sup.City = supplier.City;
                contextManager.SaveChanges();
                return RedirectToAction("DisplayAll");
            }
            return View();
        }

        public ActionResult Delete (int? id)
        {
            var sup = contextManager.Suppliers.Find(id);
            if (sup != null)
            {
                contextManager.Suppliers.Remove(sup);
                try
                {
                    contextManager.SaveChanges();
                }
                catch(Exception e)
                {
                    object obj = e.InnerException.InnerException.Message;
                    return PartialView(obj);
                }
                return RedirectToAction("DisplayAll");
            }
            return View("_error");
        }


    }
}
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
                return RedirectToAction("DisplayAll");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                var sup = contextManager.Suppliers.Find(supplier.SupID);
                sup.Name = supplier.Name;
                sup.City = supplier.City;
                return RedirectToAction("DisplayAll");
            }
            return View();
        }


    }
}
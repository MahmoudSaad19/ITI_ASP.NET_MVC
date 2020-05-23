﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Explore_ASP_Core_with_CRUD.Models;
using System.Data;

namespace Explore_ASP_Core_with_CRUD.Controllers
{
    public class ProductController : Controller
    {
        MVC_ProductsContext dbContext;

        public ProductController(MVC_ProductsContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            return View(dbContext.Products.ToList());
        }

        [HttpGet]
        public IActionResult add ()
        {
            return View();
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
            return View(product);
        }

        [HttpPost]
        public IActionResult edit(Products product)
        {
            if (ModelState.IsValid)
            {
                Products updatedproduct = dbContext.Products.Find(product.Id);
                updatedproduct.ProductName = product.ProductName;
                updatedproduct.Price = product.Price;
                updatedproduct.Units = product.Units;
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
}
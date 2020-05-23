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

        public IActionResult add ()
        {
            return View();
        }
    }
}
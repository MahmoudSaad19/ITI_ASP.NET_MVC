﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_Operations.Models;

namespace CRUD_Operations.Controllers
{
    public class StudentController : Controller
    {
        List<Student> Students = new List<Student>()
        {
            new Student() { ID = 1 , st_Name = "Ali" , Age = 20},
            new Student() { ID = 2 , st_Name = "Ola" , Age = 22},
            new Student() { ID = 3 , st_Name = "Saeed" , Age = 24},
            new Student() { ID = 4 , st_Name = "Sara" , Age = 21}
        };

        public JsonResult getAll()
        {
            return Json(Students,JsonRequestBehavior.AllowGet);
        }

        public string Insert (int id , string std , int age)
        {
            Students.Add(new Student() { Age = age, ID = id, st_Name = std });
            return "<h1>Success</h1>";
        }
    }
}
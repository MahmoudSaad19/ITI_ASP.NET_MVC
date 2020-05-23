using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_Operations_with_View_Bootstrap.Models;

namespace CRUD_Operations_with_View_Bootstrap.Controllers
{
    public class StudentController : Controller
    {
        static List<Student> Students = new List<Student>()
        {
            new Student(){ID= 1 , Address = "123st" , Age =22 , Name="Mahmoud"},
            new Student(){ID= 2 , Address = "Cairo" , Age =23 , Name="Ali"},
            new Student(){ID= 3, Address = "Giza" , Age =24 , Name="Sara"},
            new Student(){ID= 4 , Address = "Alex" , Age =25 , Name="Wael"}
        };

        public ActionResult DisplayAll ()
        {
            return View(Students);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Student s;
            if (Students.Any(std => std.ID == id))
                s = Students.FirstOrDefault(ss => ss.ID == id);
            else
                s = new Student();
            return View(s);
        }

        [HttpPost]
        public ActionResult Update(Student s)
        {
            if(s!=null && Students.Any(std=>std.ID == s.ID))
            {
                Student student = Students.Find(ss => ss.ID == s.ID);
                student.Name = s.Name;
                student.Address = s.Address;
                student.Age = s.Age;
            }
            return RedirectToAction("DisplayAll");
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Student s)
        {
            if (s != null && !Students.Any(ss => ss.ID == s.ID))
                Students.Add(s);
            return RedirectToAction("DisplayAll");
        }

        public ActionResult Delete  (int id)
        {
            Students.Remove(Students.FirstOrDefault(s => s.ID == id));
            return RedirectToAction("DisplayAll");
        }
    }
}
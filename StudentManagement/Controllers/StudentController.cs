using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            DBHandler dbhandle = new DBHandler();
            ModelState.Clear();
            return View(dbhandle.GetStudent());
        }

        [HttpPost]
        public ActionResult Index(string str)
        {
            DBHandler dbhandle = new DBHandler();
            return View(dbhandle.SearchByName(str));
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            DBHandler sdb = new DBHandler();

            return View(sdb.GetStudentById(id));
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DBHandler sdb = new DBHandler();
                    if (sdb.AddStudent(student))
                    {
                        ViewBag.Message = "Student Details Added Successfully";
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            DBHandler sdb = new DBHandler();
            return View(sdb.GetStudent().Find(smodel => smodel.id == id));
            
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                DBHandler sdb = new DBHandler();
                sdb.UpdateStudent(student);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                DBHandler sdb = new DBHandler();
                if (sdb.DeteleStudent(id))
                {
                    ViewBag.AlertMsg = "Student Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string name, string password)
        {
            try
            {
                DBHandler sdb = new DBHandler();
                if (sdb.UserLogin(name, password))
                {
                    Session["username"] = name.ToString();
                    //true
                    return RedirectToAction("Index");
                }
                else
                {
                    //false
                    return View();
                }

                
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["username"] = null;
            return RedirectToAction("Index");
        }

        

        
    }
}

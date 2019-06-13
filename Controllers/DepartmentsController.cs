using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital_Management.Models;
using Hospital_Management.SQL_Query;
namespace Hospital_Management.Controllers
{
    public class DepartmentsController : Controller
    {
        // GET: Departments
        DoctorPortal doctorPortal = new DoctorPortal();
        [HttpGet]
        public ActionResult Index()
        {
            Doctor doctor = new Doctor
            {
                AllDoctorList = doctorPortal.selectAll(),
                getAllDepartmentsName = doctorPortal.getAllDepartmentsName()
            };
            return View(doctor);
        }
        [HttpPost]
        public ActionResult Index2(FormCollection collection)
        {
            string s = collection["dept"];
            Doctor doctor = new Doctor
            {
                AllDoctorList = doctorPortal.selectAll(collection["dept"]),
                getAllDepartmentsName = doctorPortal.getAllDepartmentsName()
            };
            return View("Index", doctor);
        }
        
        public ActionResult Search(FormCollection collection)
        {
            //string s = collection["dept"];
            Doctor doctor = new Doctor
            {
                AllDoctorList = doctorPortal.selectAll2(collection["name"]),
                getAllDepartmentsName = doctorPortal.getAllDepartmentsName()
            };
            return View("Index", doctor);
        }

        // GET: Departments/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Departments/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Departments/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

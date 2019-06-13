using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital_Management.Models;
using Hospital_Management.SQL_Query;
namespace Hospital_Management.Controllers
{
    public class DepartmentAddController : Controller
    {
        // GET: DepartmentAdd
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            DepartmentAdd departmentAdd = new DepartmentAdd
            {
                dept = collection["dept"]
            };
            DepartmentAddPortal departmentAddPortal = new DepartmentAddPortal();
            departmentAddPortal.insert(departmentAdd);
            return RedirectToAction("Create", "Doctor");
           
        }
    }
}
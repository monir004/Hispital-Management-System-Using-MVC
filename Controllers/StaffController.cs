using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital_Management.SQL_Query;
using Hospital_Management.Models;
namespace Hospital_Management.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        StaffPortal staffPortal = new StaffPortal();
        public ActionResult Index()
        {
            return View(staffPortal.selecAll());
        }

        // GET: Staff/Details/5
        public ActionResult Details(int id)
        {
            return View(staffPortal.select(id));
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            PatientPortal patientPortal = new PatientPortal();
            Staff staff = new Staff
            {
                getGender = patientPortal.getGender()
            };
            return View(staff);
        }

        // POST: Staff/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Staff staff = new Staff
                {
                    name=collection["name"],
                    salary=collection["salary"],
                    gender=collection["gender"],
                    address=collection["address"],
                    phone_no=collection["phone_no"]
                };
                staffPortal.insert(staff);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(int id)
        {
            Staff tempStaff = staffPortal.select(id);
            PatientPortal patientPortal = new PatientPortal();
            Staff staff = new Staff
            {
                name=tempStaff.name,
                gender=tempStaff.gender,
                salary=tempStaff.salary,
                address=tempStaff.address,
                phone_no=tempStaff.phone_no,
                getGender=patientPortal.getGender()
            };
            return View(staff);
        }

        // POST: Staff/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {

                Staff staff = new Staff
                {
                    id = Convert.ToInt32(collection["id"]),
                    name = collection["name"],
                    salary = collection["salary"],
                    gender = collection["gender"],
                    address = collection["address"],
                    phone_no = collection["phone_no"]
                };
                staffPortal.update(staff);
                return RedirectToAction("Index");
               
            }
            catch
            {
                return View();
            }
        }

        // GET: Staff/Delete/5
        public ActionResult Delete(int id)
        {
            return View(staffPortal.select(id));
        }

        // POST: Staff/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                staffPortal.delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

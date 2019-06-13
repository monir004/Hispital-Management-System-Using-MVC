using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital_Management.Models;
using Hospital_Management.SQL_Query;
//public List<SelectListItem> getAllDoctorsName { get; set; }
//public List<SelectListItem> getAllPatientsName { get; set; }
//public List<SelectListItem> getAllVisitBills { get; set; }
namespace Hospital_Management.Controllers
{
    public class DoctorBillController : Controller
    {
        PatientPortal patientPortal = new PatientPortal();
        DoctorPortal doctorPortal = new DoctorPortal();
        DoctorBillPortal doctorBillPortal = new DoctorBillPortal();

        public ActionResult Index()
        {
            DoctorBill doctorBill = new DoctorBill()
            {
                getAllDoctorsName = doctorPortal.getAllDoctorsName(),
                getAllPatientsName=patientPortal.getAllPatientsName(),
                getAllVisitBills=doctorBillPortal.getAllVisitBills()
            };
            return View(doctorBill);
        }

        // GET: DoctorBill/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DoctorBill/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoctorBill/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        { 

            DoctorBill doctorBill = new DoctorBill
            {
                p_id = Convert.ToInt32(collection["p_id"]),
                d_id = Convert.ToInt32(collection["d_id"]),
                visit_bill = Convert.ToInt32(collection["visit_bill"]),
                days = Convert.ToInt32(collection["days"])
            };
            doctorBill.total_bill = doctorBill.visit_bill * doctorBill.days;

            DoctorBillPortal doctorBillPortal = new DoctorBillPortal();
            doctorBillPortal.insert(doctorBill);
            
            return RedirectToAction("Index");
           
        }

        // GET: DoctorBill/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DoctorBill/Edit/5
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

        // GET: DoctorBill/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DoctorBill/Delete/5
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

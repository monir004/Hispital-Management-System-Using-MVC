using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital_Management.Models;
using Hospital_Management.SQL_Query;


namespace Hospital_Management.Controllers
{
    public class RoomBillController : Controller
    {
        PatientPortal patientPortal = new PatientPortal();
        public ActionResult Index()
        {
            RoomBill roomBill = new RoomBill
            {
                getRoomType=patientPortal.getRoomType(),
                getAllPatientsName=patientPortal.getAllPatientsName()
            };
            return View(roomBill);
        }

        // GET: RoomBill/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoomBill/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomBill/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            RoomBillPortal roomBillPortal = new RoomBillPortal();
            RoomBill roomBill = new RoomBill
            {
                p_id=Convert.ToInt32(collection["p_id"]),
                r_id = Convert.ToInt32(collection["r_id"]),
                days = Convert.ToInt32(collection["days"]),
               
                
            };
            roomBill.per_day_tk = roomBillPortal.getPerDaysTaka(roomBill.r_id);
            roomBill.total_bill = roomBill.days * roomBill.per_day_tk;
            roomBillPortal.insert(roomBill);
            return RedirectToAction("Index");
            
        }

        // GET: RoomBill/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RoomBill/Edit/5
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

        // GET: RoomBill/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoomBill/Delete/5
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

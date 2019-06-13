using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital_Management.SQL_Query;
using Hospital_Management.Models;
namespace Hospital_Management.Controllers
{
    public class MedicineController : Controller
    {
        // GET: Medicine
        MedicinePortal medicinePortal = new MedicinePortal(); 
        public ActionResult Index()
        {
            Medicine medicine = new Medicine()
            {
                getAllMedicinesList=medicinePortal.selectAll(),
                getAllBrandsDistinctName = medicinePortal.getAllBrandsDistinctName()

            };
            return View(medicine);

        }
        public ActionResult Index2(FormCollection collection)
        {
            //string s = collection["dept"];
            Medicine medicine = new Medicine
            {
                getAllMedicinesList = medicinePortal.selectAll(collection["brand"]),
                getAllBrandsDistinctName =medicinePortal.getAllBrandsDistinctName()
            };
            return View("Index", medicine);
        }
        // GET: Medicine/Details/5
        public ActionResult Details(int id)
        {
            Medicine medicine = medicinePortal.select(id);
            return View(medicine);
        }

        // GET: Medicine/Create
        public ActionResult Create()
        {
            Medicine medicine = new Medicine
            {
                getAllPharmaceuticalCompany = medicinePortal.getAllpharmaceuticalCompany()
            };
            return View(medicine);
        }

        // POST: Medicine/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Medicine medicine = new Medicine
                {
                    name = collection["name"],
                    stock = Convert.ToInt32(collection["stock"]),
                    price=Convert.ToInt32(collection["price"]),
                    brand=collection["brand"]
                };
                medicinePortal.insert(medicine);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Medicine/Edit/5
        public ActionResult Edit(int id)
        {
            return View(medicinePortal.select(id));
        }

        // POST: Medicine/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Medicine medicine = new Medicine
                {
                    id = Convert.ToInt32(collection["id"]),
                    name = collection["name"],
                    stock = Convert.ToInt32(collection["stock"]),
                    price = Convert.ToInt32(collection["price"]),
                    brand = collection["brand"]
                };
                medicinePortal.update(medicine);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Medicine/Delete/5
        public ActionResult Delete(int id)
        {
            return View(medicinePortal.select(id));
        }

        // POST: Medicine/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                medicinePortal.delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

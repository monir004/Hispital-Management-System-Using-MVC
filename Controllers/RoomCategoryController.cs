using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital_Management.Models;
using Hospital_Management.SQL_Query;
namespace Hospital_Management.Controllers
{
    public class RoomCategoryController : Controller
    {
        RoomCategoryPortal roomCategoryPortal = new RoomCategoryPortal();
        public ActionResult Index()
        {
            return View(roomCategoryPortal.selectAll());
        }

        // GET: RoomCategory/Details/5
        public ActionResult Details(int id)
        {
            return View(roomCategoryPortal.select(id));
        }

        // GET: RoomCategory/Create
        public ActionResult Create()
        {
            RoomCategory roomCategory = new RoomCategory
            {
                getRoomType=roomCategoryPortal.getRoomType()
            };
            return View(roomCategory);
        }

        // POST: RoomCategory/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            RoomCategory roomCategory = new RoomCategory
            {
                type=collection["type"],
                per_day_tk=Convert.ToInt32(collection["per_day_tk"])
            };
            roomCategoryPortal.insert(roomCategory);
            return RedirectToAction("Index");
           
        }

        // GET: RoomCategory/Edit/5
        public ActionResult Edit(int id)
        {
            return View(roomCategoryPortal.select(id));
        }

        // POST: RoomCategory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                RoomCategory roomCategory = new RoomCategory
                {
                    id = Convert.ToInt32(collection["id"]),
                    type = collection["type"],
                    per_day_tk = Convert.ToInt32(collection["per_day_tk"])
                };
                roomCategoryPortal.update(roomCategory);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RoomCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View(roomCategoryPortal.select(id));
        }

        // POST: RoomCategory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            roomCategoryPortal.delete(id);
            return RedirectToAction("Index");
           
        }
    }
}

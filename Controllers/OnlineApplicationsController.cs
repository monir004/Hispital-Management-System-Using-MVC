using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital_Management.Models;
using Hospital_Management.SQL_Query;
namespace Hospital_Management.Controllers
{
    public class OnlineApplicationsController : Controller
    {
        // GET: OnlineApplications
        PatientPortal patientPortal = new PatientPortal();
        DoctorPortal doctorPortal = new DoctorPortal();
        public ActionResult Index()
        {
            Patient patient = new Patient
            {
                getRoomType = patientPortal.getRoomType(),
                getGender = patientPortal.getGender(),
                getBloodGroup = patientPortal.getBloodGroup(),
                getAllDoctorsName=doctorPortal.getAllDoctorsName()
                
            };
            return View(patient);
           
        }

        
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            ApplicationsPortal applicationsPortal = new ApplicationsPortal();
            Applications applications = new Applications
            {
                name = collection["name"],
                gender = collection["gender"],
                doctor_name=collection["doctor_name"],
                room_type = collection["room_type"],
                age = Convert.ToInt32(collection["age"]),
                blood = collection["blood"],
                address = collection["address"],
                phone_no = collection["phone_no"],
                status = "requested"
            };
            applicationsPortal.insert(applications);
            return RedirectToAction("Index");
        }

       
    }
}

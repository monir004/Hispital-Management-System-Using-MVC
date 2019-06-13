using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital_Management.SQL_Query;
using Hospital_Management.Models;
namespace Hospital_Management.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patients
        PatientPortal patientPortal = new PatientPortal();
        DoctorPortal doctorPortal = new DoctorPortal();
        public ActionResult Index()
        {
            Patient patient = new Patient
            {
                getAllPatienstList=patientPortal.selectAll(),
                getRoomType=patientPortal.getRoomType(),
                getAllDoctorsName=doctorPortal.getAllDoctorsName()
            };

            return View(patient);
        }
        public ActionResult Index2(FormCollection collection)
        {
            Patient patient = new Patient
            {
                getAllPatienstList = patientPortal.selectAll(collection["room_type"]),
                getRoomType = patientPortal.getRoomType()
            };

            return View("Index", patient);
        }
        // GET: Patients/Details/5
        public ActionResult Details(int id)
        {
            return View(patientPortal.select(id));
        }


        // GET: Patients/Create
        public ActionResult Create()
        {
            Patient patient = new Patient
            {
                getRoomType=patientPortal.getRoomType(),
                getAllDoctorsName=doctorPortal.getAllDoctorsName(),
                getGender = patientPortal.getGender(),
                getBloodGroup = patientPortal.getBloodGroup()
            };
            return View(patient);
        }

        // POST: Patients/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Patient patient = new Patient
                {
                    name = collection["name"],
                    gender = collection["gender"],
                    doctor_name = collection["doctor_name"],
                    room_type = collection["room_type"],
                    age = Convert.ToInt32(collection["age"]),
                    blood = collection["blood"],
                    address =collection["address"],
                    phone_no=collection["phone_no"]
                };
                patientPortal.insert(patient);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int id)
        {
            Patient tempPatient = patientPortal.select(id);
            Patient patient = new Patient
            {
                name = tempPatient.name,
                gender = tempPatient.gender,
                doctor_name = tempPatient.doctor_name,
                room_type = tempPatient.room_type,
                age =tempPatient.age,
                blood = tempPatient.blood,
                address =tempPatient.address,
                phone_no=tempPatient.phone_no,
                getGender = patientPortal.getGender(),
                getBloodGroup = patientPortal.getBloodGroup(),
                getRoomType=patientPortal.getRoomType(),
                getAllDoctorsName=doctorPortal.getAllDoctorsName()
            };
            return View(patient);
        }

        // POST: Patients/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Patient patient = new Patient
                {
                    //all the form values coming as a string...
                    id = Convert.ToInt32(collection["id"]),
                    name = collection["name"],
                    gender = collection["gender"],
                    doctor_name = collection["doctor_name"],
                    room_type = collection["room_type"],
                    age =Convert.ToInt32(collection["age"]),
                    blood=collection["blood"],
                    address=collection["address"],
                    phone_no=collection["phone_no"]
                };
                patientPortal.update(patient);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int id)
        {
            return View(patientPortal.select(id));
        }

        // POST: Patients/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                patientPortal.delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

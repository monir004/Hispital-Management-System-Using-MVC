using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital_Management.Models;
using System.Data.SqlClient;
using System.Configuration;
using Hospital_Management.SQL_Query;
namespace Hospital_Management.Controllers
{
    public class BillController : Controller
    {
        BillPortal billPortal = new BillPortal();
        public ActionResult Index()
        {
            Bill bill = new Bill
            {
                getAllPatients = billPortal.getAllPatients(),
                getAllStaffs = billPortal.getAllStaffs()
            };
            return View(bill);
        }

       
        [HttpPost]
        public ActionResult BillCalculations(FormCollection collection)
        {
            int is_patient_inserted_medicine_purchase_table,is_patient_inserted_doctor_purchase_table,is_patient_inserted_room_bill_table;
            Bill bill = new Bill
            {
                p_id = Convert.ToInt32(collection["p_id"]),
                s_id = Convert.ToInt32(collection["s_id"])
            };
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select count(*) from medicine_purchase where p_id=" + bill.p_id;
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                is_patient_inserted_medicine_purchase_table = (int)sqlCommand.ExecuteScalar();
                query = "select count(*) from doctor_bill where p_id=" + bill.p_id;
                sqlCommand = new SqlCommand(query, conn);
                is_patient_inserted_doctor_purchase_table = (int)sqlCommand.ExecuteScalar();
                query = "select count(*) from room_category_bill where p_id=" + bill.p_id;
                sqlCommand = new SqlCommand(query, conn);
                is_patient_inserted_room_bill_table = (int)sqlCommand.ExecuteScalar();
            }
            if(is_patient_inserted_doctor_purchase_table>0)
            {
                bill.doctor_bill = billPortal.getDoctorBill(bill.p_id);
            }
            else
            {
                bill.doctor_bill = 0;
            }
            if (is_patient_inserted_medicine_purchase_table > 0)
            {
                bill.medicine_bill = billPortal.getMedicineBill(bill.p_id);
            }
            else
            {
                bill.medicine_bill = 0;
            }
            if (is_patient_inserted_room_bill_table > 0)
            {
                bill.room_bill = billPortal.getRoomBill(bill.p_id);
            }
            else
            {
                bill.room_bill = 0;
            }
            
            bill.total_bill = bill.doctor_bill + bill.medicine_bill + bill.room_bill;
            bill.patient_name =billPortal.getPatientName(bill.p_id);
            bill.staff_name =billPortal.getStaffName(bill.s_id);
            bill.date = DateTime.Now;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "delete from patient where id=" + bill.p_id;
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }
                return View(bill);
        }

      
    }
}

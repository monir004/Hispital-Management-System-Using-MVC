using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital_Management.Models;
using System.Configuration;
//public List<SelectListItem> getAllDoctorsName { get; set; }
//public List<SelectListItem> getAllPatientsName { get; set; }
//public List<SelectListItem> getAllVisitBills { get; set; }
namespace Hospital_Management.SQL_Query
{
    public class DoctorBillPortal
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public void insert(DoctorBill doctorBill)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "insert into doctor_bill values(@p_id,@d_id,@visit_bill,@days,@total_bill)";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Parameters.AddWithValue("@p_id", doctorBill.p_id);
                sqlCommand.Parameters.AddWithValue("@d_id", doctorBill.d_id);
                sqlCommand.Parameters.AddWithValue("@visit_bill", doctorBill.visit_bill);
                sqlCommand.Parameters.AddWithValue("@days", doctorBill.days);
                sqlCommand.Parameters.AddWithValue("@total_bill", doctorBill.total_bill);
                
                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        public List<SelectListItem> getAllVisitBills()
        {
            List<SelectListItem> myList = new List<SelectListItem>();
            var data = new[]{
                 new SelectListItem{ Text="200",Value="1"},
                 new SelectListItem{ Text="300",Value="2"},
                 new SelectListItem{ Text="400",Value="3"},
                 new SelectListItem{ Text="500",Value="4"},
                 new SelectListItem{ Text="700",Value="5"},
                 new SelectListItem{ Text="800",Value="6"},
                 new SelectListItem{ Text="900",Value="7"},
                 new SelectListItem{ Text="1000",Value="8"},
                 new SelectListItem{ Text="1500", Value = "9" },
                 new SelectListItem{ Text="2000", Value = "10" }
             };
            myList = data.ToList();
            return myList;
        }
    }
}
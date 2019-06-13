using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital_Management.Models;
//int doctorBill = billPortal.getDoctorBill();
//int medicineBill = billPortal.getMedicineBill();
//int room_bill = billPortal.getRoomBill();

//string patient_name = billPortal.getPatientName();
//string staff_name = billPortal.getStaffName();

namespace Hospital_Management.SQL_Query
{
    public class BillPortal
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public int getDoctorBill(int p_id)
        {
            int total_doctor_bill=0;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "SELECT SUM(total_bill) FROM doctor_bill WHERE p_id="+p_id;
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                total_doctor_bill = (int)sqlCommand.ExecuteScalar();
            }
            return total_doctor_bill;
        }

        public int getMedicineBill(int p_id)
        {
            int total_medicine_bill = 0;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "SELECT SUM(total_bill) FROM medicine_purchase where p_id=" + p_id;
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                total_medicine_bill = (int)sqlCommand.ExecuteScalar();
            }
            return total_medicine_bill;
        }
        public int getRoomBill(int p_id)
        {
            int total_room_bill = 0;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "SELECT SUM(total_bill) from room_category_bill where p_id=" + p_id;
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                total_room_bill = (int)sqlCommand.ExecuteScalar();
            }
            return total_room_bill;
        }
        public string getPatientName(int p_id)
        {
            string patient_name;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "SELECT name FROM patient where id=" + p_id;
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                patient_name = (string)sqlCommand.ExecuteScalar();
            }
            return patient_name;
        }
        public string getStaffName(int s_id)
        {
            string staff_name;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "SELECT name FROM staff where id=" + s_id;
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                staff_name = (string)sqlCommand.ExecuteScalar();
            }
            return staff_name;
        }



        public List<SelectListItem> getAllPatients()
        {
            DataTable dataTable = new DataTable();
            List<SelectListItem> list = new List<SelectListItem>();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select * from patient";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                sqlDataAdapter.Fill(dataTable);
            }
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                string name = row[1].ToString();
                string id = row[0].ToString();
                SelectListItem temp = new SelectListItem() { Text = name, Value = id };
                list.Add(temp);
            }
            return list;
        }

        public List<SelectListItem> getAllStaffs()
        {
            DataTable dataTable = new DataTable();
            List<SelectListItem> list = new List<SelectListItem>();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select * from staff";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                sqlDataAdapter.Fill(dataTable);
            }
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                string name = row[1].ToString();
                string id = row[0].ToString();
                SelectListItem temp = new SelectListItem() { Text = name, Value = id };
                list.Add(temp);
            }
            return list;
        }
    }
}
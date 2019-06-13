using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using Hospital_Management.Models;
using System.Data;
namespace Hospital_Management.SQL_Query
{
    public class StaffPortal
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public List<Staff> selecAll()
        {
            List<Staff> staffs = new List<Staff>();
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select * from staff";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                sqlDataAdapter.Fill(dataTable);
            }
            for(int i=0;i<dataTable.Rows.Count;i++)
            {
                DataRow row = dataTable.Rows[i];
                Staff staff = new Staff
                {
                    id = Convert.ToInt32(row[0].ToString()),
                    name = row[1].ToString(),
                    salary=row[2].ToString(),
                    gender=row[3].ToString(),
                    address=row[4].ToString(),
                    phone_no=row[5].ToString()
                };
                staffs.Add(staff);
            }
            return staffs;
        }
        public Staff select(int id)
        {
            Staff staff;
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select * from staff where id=" + id;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                sqlDataAdapter.Fill(dataTable);
                DataRow row = dataTable.Rows[0];
                staff = new Staff
                {
                    id = Convert.ToInt32(row[0].ToString()),
                    name = row[1].ToString(),
                    salary = row[2].ToString(),
                    gender = row[3].ToString(),
                    address = row[4].ToString(),
                    phone_no = row[5].ToString()
                };
            }
            return staff;
        }
        public void insert(Staff staff)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "insert into staff values(@name,@salary,@gender,@address,@phone_no)";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Parameters.AddWithValue("@name", staff.name);
                sqlCommand.Parameters.AddWithValue("@salary", staff.salary);
                sqlCommand.Parameters.AddWithValue("@gender", staff.gender);
                sqlCommand.Parameters.AddWithValue("@address", staff.address);
                sqlCommand.Parameters.AddWithValue("@phone_no", staff.phone_no);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
        public void update(Staff staff)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "update staff set name=@name,salary=@salary,gender=@gender,address=@address,phone_no=@phone_no where id=@id";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Parameters.AddWithValue("@id", staff.id);
                sqlCommand.Parameters.AddWithValue("@name", staff.name);
                sqlCommand.Parameters.AddWithValue("@salary", staff.salary);
                sqlCommand.Parameters.AddWithValue("@gender", staff.gender);
                sqlCommand.Parameters.AddWithValue("@address", staff.address);
                sqlCommand.Parameters.AddWithValue("@phone_no", staff.phone_no);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
        public void delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "delete from staff where id=" + id;
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
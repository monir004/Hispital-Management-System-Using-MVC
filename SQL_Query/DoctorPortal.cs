using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using Hospital_Management.Models;
using System.Data;
using System.Web.Mvc;

namespace Hospital_Management.SQL_Query
{
    public class DoctorPortal
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public List<SelectListItem> getAllDoctorsName()
        {
            DataTable dataTable = new DataTable();
            List<SelectListItem> list = new List<SelectListItem>();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select * from doctor";
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

        public List<SelectListItem> getAllDepartmentsName()
        {
            DataTable dataTable = new DataTable();
            List<SelectListItem> list = new List<SelectListItem>();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select DISTINCT dept_name from departments";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                sqlDataAdapter.Fill(dataTable);
            }
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                string name = row[0].ToString();
                SelectListItem temp = new SelectListItem() { Text = name, Value = i.ToString() };
                list.Add(temp);
            }
            return list;
        }

        public List<Doctor> selectAll()
        {
            List<Doctor> doctors = new List<Doctor>();
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select * from doctor";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query,conn);
                sqlDataAdapter.Fill(dataTable);
            }
            for(int i=0;i<dataTable.Rows.Count;i++)
            {
                DataRow row = dataTable.Rows[i];
                Doctor doctor = new Doctor
                {
                    id = Convert.ToInt32(row[0].ToString()),
                    name = row[1].ToString(),
                    qualification = row[2].ToString(),
                    dept = row[3].ToString(),
                    designation = row[4].ToString(),
                    gender = row[5].ToString(),
                    phone_no = row[6].ToString(),
                    ImagePath=row[7].ToString()
                };
                doctors.Add(doctor);
            }
            return doctors;
        }

        public List<Doctor> selectAll(string name)
        {
            List<Doctor> doctors = new List<Doctor>();
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select * from doctor where dept=@name";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@name", name);
                sqlDataAdapter.Fill(dataTable);
            }
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                Doctor doctor = new Doctor
                {
                    id = Convert.ToInt32(row[0].ToString()),
                    name = row[1].ToString(),
                    qualification = row[2].ToString(),
                    dept = row[3].ToString(),
                    designation = row[4].ToString(),
                    gender = row[5].ToString(),
                    phone_no = row[6].ToString(),
                    ImagePath = row[7].ToString()
                };
                doctors.Add(doctor);
            }
            return doctors;
        }

        public List<Doctor> selectAll2(string name)
        {
            List<Doctor> doctors = new List<Doctor>();
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select * from doctor where name LIKE '%"+name+"%'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                //sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@name", name);
                sqlDataAdapter.Fill(dataTable);
            }
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                Doctor doctor = new Doctor
                {
                    id = Convert.ToInt32(row[0].ToString()),
                    name = row[1].ToString(),
                    qualification = row[2].ToString(),
                    dept = row[3].ToString(),
                    designation = row[4].ToString(),
                    gender = row[5].ToString(),
                    phone_no = row[6].ToString(),
                    ImagePath = row[7].ToString()
                };
                doctors.Add(doctor);
            }
            return doctors;
        }

        public Doctor select(int id)
        {
            Doctor doctor = new Doctor();
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select * from doctor where id="+id;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                sqlDataAdapter.Fill(dataTable);
                DataRow row = dataTable.Rows[0];
                doctor.id = Convert.ToInt32(row[0].ToString());
                doctor.name = row[1].ToString();
                doctor.qualification = row[2].ToString();
                doctor.dept = row[3].ToString();
                doctor.designation = row[4].ToString();
                doctor.gender = row[5].ToString();
                doctor.phone_no = row[6].ToString();
            }
            return doctor;
        }
        public void insert(Doctor doctor)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "INSERT INTO doctor(name,qualification,dept,designation,gender,phone_no,ImagePath) VALUES (@name,@qualification,@dept,@designation,@gender,@phone_no,@ImagePath)";
                SqlCommand sqlcmd = new SqlCommand(query, conn);
                sqlcmd.Parameters.AddWithValue("@name", doctor.name);
                sqlcmd.Parameters.AddWithValue("@qualification", doctor.qualification);
                sqlcmd.Parameters.AddWithValue("@dept", doctor.dept);
                sqlcmd.Parameters.AddWithValue("@designation", doctor.designation);
                sqlcmd.Parameters.AddWithValue("@gender", doctor.gender);
                sqlcmd.Parameters.AddWithValue("@phone_no", doctor.phone_no);
                sqlcmd.Parameters.AddWithValue("@ImagePath", doctor.ImagePath);
                conn.Open();
                sqlcmd.ExecuteNonQuery();
            }
        }
        public void update(Doctor doctor)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "UPDATE doctor SET name=@name, qualification=@qualification,dept=@dept, designation=@designation, gender=@gender,phone_no=@phone_no WHERE id=@id";
                SqlCommand sqlcmd = new SqlCommand(query, conn);
                sqlcmd.Parameters.AddWithValue("@id", doctor.id);
                sqlcmd.Parameters.AddWithValue("@name", doctor.name);
                sqlcmd.Parameters.AddWithValue("@qualification", doctor.qualification);
                sqlcmd.Parameters.AddWithValue("@dept", doctor.dept);
                sqlcmd.Parameters.AddWithValue("@designation", doctor.designation);
                sqlcmd.Parameters.AddWithValue("@gender", doctor.gender);
                sqlcmd.Parameters.AddWithValue("@phone_no", doctor.phone_no);
                conn.Open();
                sqlcmd.ExecuteNonQuery();
            }
        }
        public void delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "Delete from doctor where id=" + id;
                SqlCommand sqlcmd = new SqlCommand(query, conn);
                conn.Open();
                sqlcmd.ExecuteNonQuery();
            }
        }

    }
}
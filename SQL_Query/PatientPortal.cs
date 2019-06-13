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
    public class PatientPortal
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public List<SelectListItem>getAllPatientsName()
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
                string id = row[0].ToString();
                string name = row[1].ToString();
                SelectListItem temp = new SelectListItem() { Text = name, Value = id};
                list.Add(temp);
            }
            return list;
        }
        public List<Patient>selectAll()
        {
            List<Patient> patients = new List<Patient>();
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select * from patient";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                sqlDataAdapter.Fill(dataTable);
            }
            for(int i=0;i<dataTable.Rows.Count;i++)
            {
                DataRow row = dataTable.Rows[i];
                Patient patient = new Patient
                {
                    id = Convert.ToInt32(row[0].ToString()),
                    name = row[1].ToString(),
                    gender = row[2].ToString(),
                    doctor_name = row[3].ToString(),
                    room_type = row[4].ToString(),
                    age = Convert.ToInt32(row[5].ToString()),
                    blood = row[6].ToString(),
                    address = row[7].ToString(),
                    phone_no = row[8].ToString()
                    
                };
                patients.Add(patient);
            }
            return patients;
        }

        public List<Patient> selectAll(string name)
        {
            List<Patient> patients = new List<Patient>();
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select * from patient where room_type=@room_type";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@room_type", name);
                sqlDataAdapter.Fill(dataTable);
            }
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                Patient patient = new Patient
                {
                    id = Convert.ToInt32(row[0].ToString()),
                    name = row[1].ToString(),
                    gender = row[2].ToString(),
                    doctor_name = row[3].ToString(),
                    room_type = row[4].ToString(),
                    age = Convert.ToInt32(row[5].ToString()),
                    blood = row[6].ToString(),
                    address = row[7].ToString(),
                    phone_no = row[8].ToString()

                };
                patients.Add(patient);
            }
            return patients;
        }

        public Patient select(int id)
        {
            Patient patient;
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select * from patient where id=" + id;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                sqlDataAdapter.Fill(dataTable);
                DataRow row = dataTable.Rows[0];
                patient = new Patient
                {
                    id = Convert.ToInt32(row[0].ToString()),
                    name = row[1].ToString(),
                    gender = row[2].ToString(),
                    doctor_name = row[3].ToString(),
                    room_type = row[4].ToString(),
                    age = Convert.ToInt32(row[5].ToString()),
                    blood = row[6].ToString(),
                    address = row[7].ToString(),
                    phone_no=row[8].ToString()
                };
            }
            return patient;
        }
        public void insert(Patient patient)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "insert into patient values(@name,@gender,@doctor_name,@room_type,@age,@blood,@address,@phone_no)";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Parameters.AddWithValue("@name", patient.name);
                sqlCommand.Parameters.AddWithValue("@gender", patient.gender);
                sqlCommand.Parameters.AddWithValue("@doctor_name", patient.doctor_name);
                sqlCommand.Parameters.AddWithValue("@room_type", patient.room_type);
                sqlCommand.Parameters.AddWithValue("@age", patient.age);
                sqlCommand.Parameters.AddWithValue("@blood", patient.blood);
                sqlCommand.Parameters.AddWithValue("@address", patient.address);
                sqlCommand.Parameters.AddWithValue("@phone_no", patient.phone_no);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
        public void update(Patient patient)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "update patient set name=@name,gender=@gender,doctor_name=@doctor_name,room_type=@room_type,age=@age,blood=@blood,address=@address,phone_no=@phone_no where id=@id";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Parameters.AddWithValue("@id", patient.id);
                sqlCommand.Parameters.AddWithValue("@name", patient.name);
                sqlCommand.Parameters.AddWithValue("@gender", patient.gender);
                sqlCommand.Parameters.AddWithValue("@doctor_name", patient.doctor_name);
                sqlCommand.Parameters.AddWithValue("@room_type", patient.room_type);
                sqlCommand.Parameters.AddWithValue("@age", patient.age);
                sqlCommand.Parameters.AddWithValue("@blood", patient.blood);
                sqlCommand.Parameters.AddWithValue("@address", patient.address);
                sqlCommand.Parameters.AddWithValue("@phone_no", patient.phone_no);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
        public void delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "delete from patient where id=" + id;
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
        public List<SelectListItem> getGender()
        {
            List<SelectListItem> myList = new List<SelectListItem>();
            var data = new[]{
                 new SelectListItem{ Text="Male",Value="1"},
                 new SelectListItem{ Text="Female",Value="2"}
             };
            myList = data.ToList();
            return myList;
        }
        public List<SelectListItem> getBloodGroup()
        {
            List<SelectListItem> myList = new List<SelectListItem>();
            var data = new[]{
                 new SelectListItem{ Text="O+",Value="1"},
                 new SelectListItem{ Text="O-",Value="2"},
                 new SelectListItem{ Text="A+",Value="3"},
                 new SelectListItem{ Text="A-",Value="4"},
                 new SelectListItem{ Text="B+",Value="5"},
                 new SelectListItem{ Text="B-",Value="6"},
                 new SelectListItem{ Text="AB+",Value="7"},
                 new SelectListItem{ Text="AB-",Value="8"}
             };
            myList = data.ToList();
            return myList;
        }
        
        public List<SelectListItem> getRoomType()
        {
            DataTable dataTable = new DataTable();
            List<SelectListItem> list = new List<SelectListItem>();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select * from room_category";
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
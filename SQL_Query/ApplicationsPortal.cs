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
    public class ApplicationsPortal
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public List<Patient> selectAll()
        {
            List<Patient> patients = new List<Patient>();
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select * from applications";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
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
                    doctor_name=row[3].ToString(),
                    room_type = row[4].ToString(),
                    age = Convert.ToInt32(row[5].ToString()),
                    blood = row[6].ToString(),
                    address = row[7].ToString(),
                    phone_no = row[8].ToString(),
                    status= row[9].ToString()

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
                string query = "select * from applications where id=" + id;
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
                    phone_no = row[8].ToString()
                };
            }
            return patient;
        }

        public void insert(Applications applications)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "insert into applications values(@name,@gender,@doctor_name,@room_type,@age,@blood,@address,@phone_no,@status)";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Parameters.AddWithValue("@name", applications.name);
                sqlCommand.Parameters.AddWithValue("@gender", applications.gender);
                sqlCommand.Parameters.AddWithValue("@doctor_name", applications.doctor_name);
                sqlCommand.Parameters.AddWithValue("@room_type", applications.room_type);
                sqlCommand.Parameters.AddWithValue("@age", applications.age);
                sqlCommand.Parameters.AddWithValue("@blood", applications.blood);
                sqlCommand.Parameters.AddWithValue("@address", applications.address);
                sqlCommand.Parameters.AddWithValue("@phone_no", applications.phone_no);
                sqlCommand.Parameters.AddWithValue("@status", applications.status);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
        public void delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "delete from applications where id=" + id;
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
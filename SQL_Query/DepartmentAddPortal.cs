using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using Hospital_Management.Models;
using Hospital_Management.SQL_Query;
namespace Hospital_Management.SQL_Query
{
    public class DepartmentAddPortal
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public void insert(DepartmentAdd departmentAdd)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "insert into departments values(@dept_name)";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Parameters.AddWithValue("@dept_name", departmentAdd.dept);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
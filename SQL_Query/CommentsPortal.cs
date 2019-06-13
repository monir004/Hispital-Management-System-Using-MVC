using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using Hospital_Management.Models;

namespace Hospital_Management.SQL_Query
{
    public class CommentsPortal
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public List<Comments> selectAll()
        {
            List<Comments> comments = new List<Comments>();
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select * from comments";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                sqlDataAdapter.Fill(dataTable);
            }
            int size = dataTable.Rows.Count;
            for (int i = size-1; i >=0; i--)
            {
                DataRow row = dataTable.Rows[i];
                Comments comment = new Comments
                {
                    id = Convert.ToInt32(row[0].ToString()),
                    name = row[1].ToString(),
                    date = Convert.ToDateTime(row[2]),
                    body = row[3].ToString()

                };
                comments.Add(comment);
            }
            return comments;
        }
    }
}
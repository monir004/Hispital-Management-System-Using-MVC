using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital_Management.Models;
namespace Hospital_Management.SQL_Query
{
    public class RoomBillPortal
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;



        public void insert(RoomBill roomBill)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "insert into room_category_bill values(@p_id,@r_id,@days,@per_day_tk,@total_bill)";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Parameters.AddWithValue("@p_id", roomBill.p_id);
                sqlCommand.Parameters.AddWithValue("@r_id", roomBill.r_id);
                sqlCommand.Parameters.AddWithValue("@days", roomBill.days);
                sqlCommand.Parameters.AddWithValue("@per_day_tk", roomBill.per_day_tk);
                sqlCommand.Parameters.AddWithValue("@total_bill", roomBill.total_bill);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }
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
                string id = row[2].ToString();
                SelectListItem temp = new SelectListItem() { Text = name, Value = id };
                list.Add(temp);
            }
            return list;
        }
        public int getPerDaysTaka(int id)
        {
            int per_day_tk;
            
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select per_day_tk from room_category where id=" + id;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                sqlDataAdapter.Fill(dataTable);
                DataRow row = dataTable.Rows[0];
                per_day_tk = Convert.ToInt32(row[0].ToString());
            }
            return per_day_tk;
        }

    }
}
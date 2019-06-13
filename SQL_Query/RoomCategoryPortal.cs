using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using Hospital_Management.Models;
using Hospital_Management.SQL_Query;
using System.Web.Mvc;

namespace Hospital_Management.SQL_Query
{
    public class RoomCategoryPortal
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

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

        public List<RoomCategory> selectAll()
        {
            List<RoomCategory> roomCategorys = new List<RoomCategory>();
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select * from room_category";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                sqlDataAdapter.Fill(dataTable);
            }
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                RoomCategory roomCategory = new RoomCategory
                {
                    id = Convert.ToInt32(row[0].ToString()),
                    type = row[1].ToString(),
                    per_day_tk = Convert.ToInt32(row[2].ToString())

                };
                roomCategorys.Add(roomCategory);
            }
            return roomCategorys;
        }

        public RoomCategory select(int id)
        {
            RoomCategory roomCategory;
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select * from room_category where id=" + id;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                sqlDataAdapter.Fill(dataTable);
                DataRow row = dataTable.Rows[0];
                roomCategory = new RoomCategory
                {
                    id = Convert.ToInt32(row[0].ToString()),
                    type = row[1].ToString(),
                    per_day_tk = Convert.ToInt32(row[2].ToString())
                };
            }
            return roomCategory;
        }
        public void insert(RoomCategory roomCategory)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "insert into room_category values(@type,@per_day_tk)";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Parameters.AddWithValue("@type", roomCategory.type);
                sqlCommand.Parameters.AddWithValue("@per_day_tk", roomCategory.per_day_tk);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void update(RoomCategory roomCategory)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "update room_category set type=@type,per_day_tk=@per_day_tk where id=@id";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Parameters.AddWithValue("@id", roomCategory.id);
                sqlCommand.Parameters.AddWithValue("@type", roomCategory.type);
                sqlCommand.Parameters.AddWithValue("@per_day_tk", roomCategory.per_day_tk);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "delete from room_category where id=" + id;
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

    }
}
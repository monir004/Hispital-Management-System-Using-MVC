using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Hospital_Management.Models;
namespace Hospital_Management.SQL_Query
{
    public class MedicinePurchasePortal
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public void updateProductQuantity(int id)
        {
            int quantity;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select stock from medicine where id=" + id;
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                quantity = (int)sqlCommand.ExecuteScalar();
                quantity -= id;
                query = "update medicine set stock=@quantity where id="+id;
                sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Parameters.AddWithValue("@quantity", quantity);
                sqlCommand.ExecuteNonQuery();

            }
        }
        public int getMedicinePrice(int id)
        {
            int price;
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select price from medicine where id=" + id;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                sqlDataAdapter.Fill(dataTable);
                DataRow row = dataTable.Rows[0];
                price = Convert.ToInt32(row[0]); 
            }
            return price;
        }

        public void insert(Medicine_Purchase medicine_Purchase)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "insert into medicine_purchase values(@p_id,@m_id,@quantity,@total_bill,@date)";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Parameters.AddWithValue("@p_id", medicine_Purchase.patient_id);
                sqlCommand.Parameters.AddWithValue("@m_id", medicine_Purchase.medicine_id);
                sqlCommand.Parameters.AddWithValue("@quantity", medicine_Purchase.quantitly);
                sqlCommand.Parameters.AddWithValue("@total_bill", medicine_Purchase.total_bill);
                sqlCommand.Parameters.AddWithValue("@date", medicine_Purchase.dateTime);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

    }
}
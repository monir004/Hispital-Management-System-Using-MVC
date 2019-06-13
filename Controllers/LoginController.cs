using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Data;
using Hospital_Management.Models;
namespace Hospital_Management.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginCheck(FormCollection collection)
        {
            int matching_result;
            loginModel loginModel = new loginModel
            {
                username = collection["username"],
                password = collection["password"]
            };

            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "(select count(*) from login where username=@username AND password=@password)";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Parameters.AddWithValue("@username", loginModel.username);
                sqlCommand.Parameters.AddWithValue("@password", loginModel.password);

                conn.Open();
                matching_result = (int)sqlCommand.ExecuteScalar();
                //Exexute scalar returns a single value,return type is object,
                //we can convert it at any type.
            }
            if (matching_result > 0)
            {
                return RedirectToAction("Index", "Patient");
            }
            else
            {
                
                return View("WrongLogin");
            }

        }
    }
}
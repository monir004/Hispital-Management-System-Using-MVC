using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital_Management.Models;
using System.Configuration;
using System.Data.SqlClient;
using Hospital_Management.SQL_Query;
namespace Hospital_Management.Controllers
{
    public class CommentsController : Controller
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public ActionResult Index()
        {
            CommentsPortal commentsPortal = new CommentsPortal();
            Comments comments = new Comments();
            comments.getAllDetails = commentsPortal.selectAll();
            
            return View(comments);
        }

        // GET: Comments/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comments/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            Comments comments = new Comments
            {
                name=collection["name"],
                date=DateTime.Now,
                body=collection["body"]
            };
            string query = "insert into comments values(@name,@date,@body)";
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Parameters.AddWithValue("@name", comments.name);
                sqlCommand.Parameters.AddWithValue("@date", comments.date);
                sqlCommand.Parameters.AddWithValue("@body", comments.body);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }
            CommentsPortal commentsPortal = new CommentsPortal();
            comments.getAllDetails = commentsPortal.selectAll();
            return View("Index",comments);
            
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Comments/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Comments/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

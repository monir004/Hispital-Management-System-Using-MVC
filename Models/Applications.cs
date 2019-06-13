using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Hospital_Management.Models;

namespace Hospital_Management.Models
{
    public class Applications
    {
        [Display(Name = "ID")]
        public int id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string gender { get; set; }
        [Required]
        [Display(Name = "Doctor Name")]
        public string doctor_name { get; set; }
        [Required]
        [Display(Name = "Room Type")]
        public string room_type { get; set; }
        [Required]
        [Display(Name = "Age")]
        public int age { get; set; }
        [Required]
        [Display(Name = "Blood Group")]
        public string blood { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string address { get; set; }
        [RegularExpression(@"^([0-9]{11})$", ErrorMessage = "Mobile number should be 11 digits long")]
        [Display(Name = "Phone Number")]
        public string phone_no { get; set; }
        [Required]
        [Display(Name = "Status")]
        public string status { get; set; }
        public List<SelectListItem> getGender { get; set; }
        public List<SelectListItem> getBloodGroup { get; set; }
        public List<SelectListItem> getRoomType { get; set; }
        public List<SelectListItem> getAllDoctorsName { get; set; }
    }
}
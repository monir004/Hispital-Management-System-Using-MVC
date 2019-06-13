using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Hospital_Management.Models
{
    public class Staff
    {
        
        [Display(Name ="ID")]
        public int id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string gender { get; set; }
        [Required]
        [Display(Name = "Salary")]
        public string salary { get; set; }
        [Display(Name = "Address")]
        public string address { get; set; }
        [Display(Name = "Phone number")]
        [RegularExpression(@"^([0-9]{11})$", ErrorMessage = "Invalid Mobile Number.")]
        public string phone_no { get; set; }
        public List<SelectListItem> getGender { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace Hospital_Management.Models
{
    public class Doctor
    {
        [Display(Name = "ID")]
        public int id { get; set; }
        [Required]
        [Display(Name ="Name")]
        public string name { get; set; }
        [Required]
        [Display(Name ="Qualification")]
        public string qualification { get; set; }
        [Required]
        [Display(Name ="Department")]
        public string dept { get; set; }
        [Required]
        [Display(Name ="Designation")]
        public string designation { get; set; }
        [Required]
        [Display(Name="Gender")]
        public string gender { get; set; }
        [Display(Name ="Contact Number")]
        [RegularExpression(@"^([0-9]{11})$", ErrorMessage = "Mobile number should be 11 digits long")]
        public string phone_no { get; set; }
        [Display(Name ="Upload Image ")]

        public string SelectedDepartmentText { get; set; }
        public List<SelectListItem> getGender { get; set; }
        public List<SelectListItem> getAllDoctorsName { get; set; }
        public List<SelectListItem> getAllDepartmentsName { get; set; }
        public List<Doctor> AllDoctorList { get; set; }
        [Display(Name = "Image")]
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
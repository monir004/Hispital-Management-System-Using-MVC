using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_Management.Models
{
    public class DoctorBill
    {
        [Required]
        public int id { get; set; }
        [Display(Name ="Patient Name: ")]
        [Required]
        public int p_id { get; set; }
        [Display(Name ="Doctor Name: ")]
        [Required]
        public int  d_id { get; set; }
        [Display(Name ="Visit Bill: ")]
        [Required]
        public int visit_bill { get; set; }
        [Display(Name ="Days")]
        [Range(1,100)]
        
        public int days { get; set; }
        [Display(Name ="Total Bill: ")]
        public int total_bill { get; set; }

        public List<SelectListItem> getAllDoctorsName { get; set; }
        public List<SelectListItem> getAllPatientsName { get; set; }
        public List<SelectListItem> getAllVisitBills { get; set; }
    }
}
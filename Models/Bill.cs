using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_Management.Models
{
   

    public class Bill
    {
        [Required]
        [Display(Name ="Patient Name: ")]
        public int p_id { get; set; }
        [Required]
        [Display(Name = "Staff Name: ")]
        public int s_id { get; set; }

        public int doctor_bill { get; set; }
        public int medicine_bill { get; set; }
        public int room_bill { get; set; }
        public int total_bill { get; set; }
        public string patient_name { get; set; }
        public string staff_name { get; set; }
        public DateTime date { get; set; }
        public List<SelectListItem> getAllPatients { get; set; }
        public List<SelectListItem> getAllStaffs { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_Management.Models
{
    public class RoomBill
    {
        public int id { get; set; }
        [Required]
        [Display(Name ="Patient Name: ")]
        public int p_id { get; set; }
        [Required]
        [Display(Name ="Room type: ")]
        public int r_id { get; set; }
        [Required]
        [Display(Name ="Days")]
        public int days { get; set; }
        public int per_day_tk { get; set; }
        public int total_bill { get; set; }

        public List<SelectListItem> getRoomType { get; set; }
        public List<SelectListItem> getAllPatientsName { get; set; }

    }
}
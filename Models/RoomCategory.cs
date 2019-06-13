using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_Management.Models
{
    public class RoomCategory
    {
        public int id { get; set; }
        [Required]
        [Display(Name ="Type: ")]
        public string type { get; set; }
        [Required]
        [Display(Name ="Per day Taka: ")]
        public int per_day_tk { get; set; }

        public List<SelectListItem> getRoomType { get; set; }
    }
}
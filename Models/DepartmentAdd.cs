using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_Management.Models
{
    public class DepartmentAdd
    {
        [Required]
        [Display(Name ="Department Name: ")]
        public string dept { get; set; }
    }
}
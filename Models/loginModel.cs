using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management.Models
{
    public class loginModel
    {
        [Display(Name ="User Name")]
        [MinLength(2)]
        [Required(ErrorMessage = "User name is required")]
        public string username { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [MinLength(4)]
        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }
    }
}
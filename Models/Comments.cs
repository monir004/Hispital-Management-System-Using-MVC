using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Hospital_Management.Models;
namespace Hospital_Management.Models
{
    public class Comments
    {
        public int id { get; set; }
        [Required]
        [Display(Name ="Enter full name")]
        public string name { get; set; }
        public DateTime date { get; set; }
        [Display(Name ="Title")]
        [Required]
        public string header { get; set; }
        [Required]
        [Display(Name ="Comments")]
        public string body { get; set; }
        public List<Comments> getAllDetails { get; set; }
    }
}
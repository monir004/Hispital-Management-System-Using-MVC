using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Hospital_Management.Models
{
    public class Medicine
    {

        [Display(Name ="ID")]
        public int id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Range(1, 10000)]
        [Required(ErrorMessage = "Stock must greater than zero")]
        [Display(Name = "Stock")]
        public int stock { get; set; }
       
        
        [Display(Name = "Price")]
        [Range(1, 10000)]
        [Required(ErrorMessage ="Price must greater than zero")]
        public int price { get; set; }
        [Required]
        [Display(Name = "Brand")]
        public string brand { get; set; }
        public List<SelectListItem> getAllPharmaceuticalCompany { get; set; }
        public List<SelectListItem> getAllBrandsDistinctName { get; set; }
        public List<Medicine> getAllMedicinesList { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPickr.Models
{
    public class CatListItem
    {
        [Display(Name = "ID")]
        public int CatId { get; set; }
        [Display(Name = "Name")]
        public string CatName { get; set; }

        [Display(Name = "Weight")]
        public int CatWeight { get; set; }
        [Display(Name = "Age")]
        public int CatAge { get; set; }
        [Display(Name = "Price")]
        public double CatPrice { get; set; }
        [Display(Name = "Shelter Name")]
        public string ShelterName { get; set; }
    }
}

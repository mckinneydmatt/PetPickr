using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPickr.Models
{
    public class ShelterListItem
    {
        [Display(Name = "Shelter ID")]
        public int ShelterId { get; set; }
        [Display(Name = "Shelter Name")]
        public string ShelterName { get; set; }
        [Display(Name = "Shelter Address")]
        public string ShelterAddress { get; set; }
        [Display(Name = "Shelter Phone Number")]
        public string ShelterPhoneNumber { get; set; }
    }
}

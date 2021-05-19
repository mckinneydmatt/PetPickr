using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPickr.Models
{
    public class ShelterCreate
    {
        [Display(Name = "Shelter Name")]
        [Required]
        public string ShelterName { get; set; }
        [Required]
        [Display(Name = "Shelter Address")]
        public string ShelterAddress { get; set; }
        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Shelter Phone Number")]
        public string ShelterPhoneNumber { get; set; }

    }
}

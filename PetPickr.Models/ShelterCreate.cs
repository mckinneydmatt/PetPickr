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
        [Required]
        public string ShelterName { get; set; }
        [Required]
        public string ShelterAddress { get; set; }
    }
}

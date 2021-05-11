using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPickr.Data
{
    public class Shelter
    {
        [Required]
        public int ShelterId { get; set; }
        [Required]
        public string ShelterName { get; set; }
        [Required]
        public string ShelterAddress { get; set; }
    }
}

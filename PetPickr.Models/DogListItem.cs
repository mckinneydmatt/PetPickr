using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPickr.Models
{
    public class DogListItem
    {
        [Display(Name = "ID")]
        public int DogId { get; set; }
        [Display(Name = "Name")]
        public string DogName { get; set; }
        [Display(Name = "Breed")]
        public string DogBreed { get; set; }
        
   
        [Display(Name = "Price")]
        public double DogPrice { get; set; }
        [Display(Name = "Shelter Name")]
        public string ShelterName { get; set; }
    }
}

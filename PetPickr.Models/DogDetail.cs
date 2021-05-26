using PetPickr.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPickr.Models
{
    public class DogDetail
    {
        [Display(Name = "ID")]
        public int DogId { get; set; }
        [Display(Name = "Name")]
        public string DogName { get; set; }
        [Display(Name = "Breed")]
        public string DogBreed { get; set; }
        [Display(Name = "Sex")]
        public DogSex? DogSex { get; set; }
        [Display(Name = "Weight")]
        public int DogWeight { get; set; }
        [Display(Name = "Age")]
        public int DogAge { get; set; }
        [Display(Name = "Price")]
        public double DogPrice { get; set; }
        [Display(Name = "Shelter Name")]
        public string ShelterName { get; set; }
        public string DogImage { get; set; }
        public int ShelterId { get; set; }
    }
}

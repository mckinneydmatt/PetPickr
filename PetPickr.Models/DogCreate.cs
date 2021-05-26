using PetPickr.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPickr.Models
{
    public class DogCreate
    {
        
        [Required]
        [Display(Name = "Name")]
        public string DogName { get; set; }
        [Required]
        [Display(Name = "Breed")]
        public string DogBreed { get; set; }
        [Required(ErrorMessage = "Sex is required")]
        [Display(Name = "Sex")]
        public DogSex? DogSex { get; set; }
        [Required]
        [Display(Name = "Weight")]
        public int DogWeight { get; set; }
        [Required]
        [Display(Name = "Age")]
        public int DogAge { get; set; }
        [Required]
        [Display(Name = "Price")]
        public double DogPrice { get; set; }
        [ForeignKey(nameof(Shelter))]
        [Required]

        public int ShelterId { get; set; }
        [Display(Name = "Enter a link to an image of the dog. Link must be public.")]
        [Required]
        public string DogImage { get; set; }
        public virtual Shelter Shelter { get; set; }
    }
}

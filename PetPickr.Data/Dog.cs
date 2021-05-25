using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPickr.Data
{
    public enum DogSex
    {
        Male=1,
        Female=2
    }
    public class Dog
    {
        [Key]
        [Required]
        public int DogId { get; set; }
        [Required]
        public string DogName { get; set; }
        [Required]
        public string DogBreed { get; set; }
        [Range(1, 2, ErrorMessage = "Please select male or female.")]
        public DogSex? DogSex { get; set; }
        [Required]
        public int DogWeight { get; set; }
        [Required]
        public int DogAge { get; set; }
        [Required]
        public double DogPrice { get; set; }
        [ForeignKey(nameof(Shelter))]
        [Required]
        public int ShelterId { get; set; }
        public string DogImage { get; set; }
        public virtual Shelter Shelter { get; set; }
    }
}

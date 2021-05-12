using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPickr.Data
{
    public class Dog
    {
        [Key]
        [Required]
        public int DogId { get; set; }
        [Required]
        public string DogName { get; set; }
        [Required]
        public string DogBreed { get; set; }
        [Required]
        public int DogWeight { get; set; }
        [Required]
        public int DogAge { get; set; }
        [Required]
        public double DogPrice { get; set; }
        [ForeignKey(nameof(Shelter))]
        [Required]
        public int ShelterId { get; set; }

        public virtual Shelter Shelter { get; set; }
    }
}

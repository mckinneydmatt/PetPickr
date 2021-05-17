using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPickr.Data
{
    public enum CatSex
    {
        Male=1,
        Female=2
    }
    public class Cat
    {
        [Key]
        [Required]
        public int CatId { get; set; }
        [Required]
        public string CatName { get; set; }
        [Required]
        
        [Range(1, int.MaxValue, ErrorMessage = "Please select male or female.")]
        public CatSex? CatSex { get; set; }
        [Required]
        public int CatWeight { get; set; }
        [Required]
        public int CatAge { get; set; }

        [Required]
        public double CatPrice { get; set; }
        [ForeignKey(nameof(Shelter))]
        [Required]
        public int ShelterId { get; set; }

        public virtual Shelter Shelter { get; set; }
    }
}

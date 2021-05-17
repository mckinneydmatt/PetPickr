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
    public class CatCreate
    {
        [Required]
        [Display(Name = "Name")]
        public string CatName { get; set; }
        [Required(ErrorMessage ="Sex is required")]
        [Display(Name = "Sex")]
        public CatSex? CatSex { get; set; }
        [Required]
        [Display(Name = "Weight")]
        public int CatWeight { get; set; }
        [Required]
        [Display(Name = "Age")]
        public int CatAge { get; set; }
        [Required]
        [Display(Name = "Price")]
        public double CatPrice { get; set; }
        [ForeignKey(nameof(Shelter))]
        [Required]
        public int ShelterId { get; set; }
        public virtual Shelter Shelter { get; set; }

    }
}

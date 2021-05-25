using PetPickr.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPickr.Models
{
    public class CatEdit
    {
        [Display(Name = "ID")]
        public int CatId { get; set; }
        [Display(Name = "Name")]
        public string CatName { get; set; }
        [Display(Name = "Sex")]

        public CatSex? CatSex { get; set; }

        [Display(Name = "Weight")]
        public int CatWeight { get; set; }
        [Display(Name = "Age")]
        public int CatAge { get; set; }
        [Display(Name = "Price")]
        public double CatPrice { get; set; }
        [Display(Name = "Enter a link to an image of the cat. Link must be public.")]
        public string CatImage { get; set; }
        public int ShelterId { get; set; }
        public virtual Shelter Shelter { get; set; }

    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewSPCA.Models
{
    public class Breed
    {
        [Required]
        [Display(Name = "Breed")]
        public int BreedID { get; set; }    

        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Name")]
        public string Breed_Name { get; set; }

        // navigation properties
        // one breed to many animals
        public virtual ICollection<Animal> Animals { get; set; }
    }
}

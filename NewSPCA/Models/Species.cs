using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewSPCA.Models
{
    public class Species
    {
        [Required]
        [Display(Name = "Species")]
        public int SpeciesID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Name")]
        public string Species_Name { get; set; }

        // navigation properties
        // one species, many animals
        public virtual ICollection<Animal> Animals { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewSPCA.Models
{
    public class Site
    {
        public int SiteID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Site_Name { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Address cannot be longer than 150 characters.")]
        public string Site_Address { get; set; }

        [Required]
        [StringLength(60)]
        public string City { get; set; }

        [Display(Name = "Postal Code")]
        [Required]
        [StringLength(7)]
        [Column(TypeName = "nchar(7)")]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(2)]
        [Column(TypeName = "nchar(2)")]
        public string Province { get; set; }
    }
}

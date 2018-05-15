using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace NewSPCA.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        //brettdinelli: add custom properties
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(65)]
        public string LastName { get; set; }

        [Required]
        [StringLength(150)]
        public string Address { get; set; }

        [Required]
        [StringLength(60)]
        public string City { get; set; }

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

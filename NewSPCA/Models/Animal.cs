using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewSPCA.Models
{
    public class Animal
    {
        // animal properties
        /*
            these properties will become database fields within the Animal table
            by using the Entity Framework Core
            the ID property will become the primary key column of the database table
            that corresponds to this class (Animal)
            by default the Entity Framework interprets property that is named ID
            or ClassNameID as the PK
            for example: 
                - ID
                - AnimalID
        */

        public int ID { get; set; }
        
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; set; }
        
        [StringLength(25, ErrorMessage = "Age cannot be longer than 25 characters.")]
        public string Age { get; set; }
        
        public Gender Gender { get; set; }  
        
        public Size Size { get; set; }    

        [StringLength(25, ErrorMessage = "Color cannot be longer than 25 characters.")]
        public string Color { get; set; }
         
        [Display(Name = "Intake Date")]
        [DataType(DataType.Date)] // removes the time
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]    // change date format
        public DateTime Intake_Date { get; set; }
        
        [DataType(DataType.Currency)]   // client only
        [Column(TypeName = "money")]    // sql server money data type
        public decimal Price { get; set; }

        public Declawed Declawed { get; set; }

        public Housebroken Housebroken { get; set; }
        
        public Spayed_Neutered Spayed_Neutered { get; set; }

        // foreign keys
        [Required]
        public int SpeciesID { get; set; }     // FK for the Species class/table

        [Required]
        public int BreedID { get; set; }       // FK for the Breed class/table - one breed, many animals

        [Required]
        public int SiteID { get; set; }        // FK for the Site class/table

        public virtual Species Species { get; set; }

        public virtual Breed Breed { get; set; }

        public virtual Site Site { get; set; }

    }

    // gender enumeration
    public enum Gender
    {
        Male, Female, Unknown
    }

    // size enumeration
    public enum Size
    {
        Small, Medium, Large
    }

    // spayed_neutered enumeration
    public enum Spayed_Neutered
    {
        Yes, No, Unknown
    }

    public enum Declawed
    {
        Yes, No, Unknown
    }

    public enum Housebroken
    {
        Yes, No, Unknown
    }
}

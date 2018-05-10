using NewSPCA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewSPCA.Data
{
    public class DbInitializer
    {
        public static void Initialize(AnimalContext context)
        {
            // look for any animals
            if(context.Animals.Any())
            {
                return;     // db has been seeded
            }

            

            // breeds
            var breeds = new Breed[]
            {
                new Breed
                {
                    Breed_Name = "Terrier"
                },

                new Breed
                {
                    Breed_Name = "Mixed"
                },

                new Breed
                {
                    Breed_Name = "Retriever"
                },

                new Breed
                {
                    Breed_Name = "Labrador"
                },

                new Breed
                {
                    Breed_Name = "Poodle"
                },

                new Breed
                {
                    Breed_Name = "Great Pyrenees"
                },

                new Breed
                {
                    Breed_Name = "Domestic Short Hair"
                },

                new Breed
                {
                    Breed_Name = "Domestic Medium Hair"
                },

                new Breed
                {
                    Breed_Name = "Domestic Long Hair"
                }
            };

            // sites
            var sites = new Site[]
            {
                new Site
                {
                    Site_Name = "Greater Moncton SPCA",
                    Site_Address = "116 Greenock St.",
                    City = "Moncton",
                    PostalCode = "E1H 2J7",
                    Province = "NB"
                },

                new Site
                {
                    Site_Name = "Saint John SPCA Animal Rescue",
                    Site_Address = "295 Bayside Dr.",
                    City = "Saint John",
                    PostalCode = "E2J 1B1",
                    Province = "NB"
                },

                new Site
                {
                    Site_Name = "Grey Cove Veterinary Health Centre",
                    Site_Address = "140 Canaan Dr.",
                    City = "Dieppe",
                    PostalCode = "E1A 9J2",
                    Province = "NB"
                }
            };

            foreach (Site t in sites)
            {
                context.Sites.Add(t);
            }
            context.SaveChanges();

            // species
            var species = new Species[]
            {
                new Species
                {
                    Species_Name = "Dog"
                },

                new Species
                {
                    Species_Name = "Cat"
                },

                new Species
                {
                    Species_Name = "Reptile"
                },

                new Species
                {
                    Species_Name = "Small-Furry"
                }
            };

            foreach(Species s in species)
            {
                context.Species.Add(s);
            }
            context.SaveChanges();

            // do animals last - it's the parent
            var animals = new Animal[]
            {
                new Animal
                {
                    Name = "Telly",
                    SpeciesID = species.Single( i => i.Species_Name == "Dog").SpeciesID,
                    BreedID = breeds.Single( i => i.Breed_Name == "Terrier").BreedID,
                    Age = "6 years 6 months 5 days",
                    Gender = Gender.Female,
                    Size = Size.Medium,
                    Color = "Beige",
                    Spayed_Neutered = Spayed_Neutered.Yes,
                    Declawed = Declawed.No,
                    Housebroken = Housebroken.Unknown,
                    SiteID = sites.Single( i => i.Site_Name == "Greater Moncton SPCA").SiteID,
                    Intake_Date = DateTime.Parse("2017-11-05"),
                    Price = 235.00m
                },

                new Animal
                {
                    Name = "Fergus",
                    SpeciesID = species.Single( i => i.Species_Name == "Cat").SpeciesID,
                    BreedID = breeds.Single( i => i.Breed_Name == "Domestic Short Hair").BreedID,
                    Age = "5 years 3 months 14 days",
                    Gender = Gender.Male,
                    Size = Size.Large,
                    Color = "White",
                    Spayed_Neutered = Spayed_Neutered.Yes,
                    Declawed = Declawed.No,
                    Housebroken = Housebroken.Unknown,
                    SiteID = sites.Single( i => i.Site_Name == "Greater Moncton SPCA").SiteID,
                    Intake_Date = DateTime.Parse("2018-05-02"),
                    Price = 99.00m
                }

            };

            foreach(Animal a in animals)
            {
                context.Animals.Add(a);
            }
            context.SaveChanges();
        }
    }
}

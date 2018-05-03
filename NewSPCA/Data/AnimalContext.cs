using Microsoft.EntityFrameworkCore;
using NewSPCA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewSPCA.Data
{
    public class AnimalContext : DbContext
    {
        // constructor
        public AnimalContext(DbContextOptions<AnimalContext> options):base(options)
        {

        }

        // specify the entity sets - corresponding to the database tables
        // each entity corresponds to a row in a table 

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Species> Species { get; set; }

        /*
            override the default behavior by specifying singular table names using 
            the Fluent API of the Entity Framework. also, we will be mapping our
            composite PKs using this Fluent API (which is the only way to do it.)
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // change plural to singular table names
            modelBuilder.Entity<Animal>().ToTable("Animal");
            modelBuilder.Entity<Breed>().ToTable("Breed");
            modelBuilder.Entity<Site>().ToTable("Site");
            modelBuilder.Entity<Species>().ToTable("Species");

        }
    }
}

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

            var animals = new Animal[]
            {
                new Animal
                {

                },

                new Animal
                {

                },
            };
        }
    }
}

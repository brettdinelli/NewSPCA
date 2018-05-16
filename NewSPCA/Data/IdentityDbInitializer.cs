using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewSPCA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewSPCA.Data
{
    public class IdentityDbInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // create the admin role
                var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync("admin"))
                {
                    // admin role does not exist, create it
                    IdentityResult IR = await roleManager.CreateAsync(new IdentityRole("admin"));

                }

                // create the admin user
                var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

                // check if admin user already exists
                var user = await userManager.FindByEmailAsync("admin@identitydemo.com");

                if (user == null)
                {
                    // the admin user represented by admin@identitydemo.com does not exist, create it
                    user = new ApplicationUser
                    {
                        UserName = "admin@identitydemo.com",
                        Email = "admin@identitydemo.com",
                        FirstName = "admin",
                        LastName = "istrator",
                        Address = "Cameron St.",
                        City = "Moncton",
                        Province = "NB",
                        PostalCode = "E4R 2J6"
                    };

                    // add it to the database
                    await userManager.CreateAsync(user, "Admin@123456");

                    // no lockout for the admin
                    await userManager.SetLockoutEnabledAsync(user, false);

                } // end if

                // add admin user to the admin role
                IdentityResult result = await userManager.AddToRoleAsync(user, "admin");




            } // end of using statement
        } // end of method
    } // end of class
} // end of namespace

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WriteMe.Data.Entities;

namespace WriteMe.Data
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager)
        {
            string adminEmail = "admin@gmail.com";
            string password = "_Hum45678";
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                User admin = new User
                {
                    UserName = adminEmail,
                    NormalizedUserName = adminEmail.ToUpper(),
                    Email = adminEmail,
                    EmailConfirmed = true,
                    NormalizedEmail = adminEmail.ToUpper(),
                    LastActivityTime = DateTime.Now,
                    ProfilePicture = "asd"
                };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }

            string userEmail = "iwannaexplore@gmail.com";
            string userPassword = "_Hum45678";
            if (await userManager.FindByEmailAsync(userEmail) == null)
            {
                User user = new User
                {
                    UserName = userEmail,
                    NormalizedUserName = userEmail.ToUpper(),
                    Email = userEmail,
                    EmailConfirmed = true,
                    NormalizedEmail = userEmail.ToUpper(),
                    LastActivityTime = DateTime.Now,
                    ProfilePicture = "asd"
                };
                IdentityResult result = await userManager.CreateAsync(user, userPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "USER");
                }
            }

        }
    }
}

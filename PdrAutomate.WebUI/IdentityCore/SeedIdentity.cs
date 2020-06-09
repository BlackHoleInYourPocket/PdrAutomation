using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdrAutomate.WebUI.IdentityCore
{
    public static class SeedIdentity
    {
        public static async Task CreateIdentityUsers(IServiceProvider serviceProvider,IConfiguration configuration)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var username = configuration["Data:AdminUser:username"];
            var email = configuration["Data:AdminUser:email"];
            var password = configuration["Data:AdminUser:password"];
            var role = configuration["Data:AdminUser:role"];

            var teacherusername = configuration["Data:Teacher:username"];
            var teacheremail = configuration["Data:Teacher:email"];
            var teacherpassword = configuration["Data:Teacher:password"];
            var teacherrole = configuration["Data:Teacher:role"];

            if (await userManager.FindByNameAsync(username) == null)
            {
                if(await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
                ApplicationUser user = new ApplicationUser()
                {
                    UserName =username,
                    Email = email,
                    Name = "Seyfi",
                    Surname="Zeyrek"

                };

                IdentityResult result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }

            if (await userManager.FindByNameAsync(teacherusername) == null)
            {
                if (await roleManager.FindByNameAsync(teacherrole) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(teacherrole));
                }
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = teacherusername,
                    Email = teacheremail,
                    Name = "İrem",
                    Surname = "Topal"

                };
                IdentityResult result = await userManager.CreateAsync(user, teacherpassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, teacherrole);
                }
            }
        }
    }
}

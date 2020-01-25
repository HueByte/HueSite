using HueSite.Data.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HueSite.Data.Services
{
    public class Admin : IAdmin
    {

        UserManager<IdentityUser> userManager;
        RoleManager<IdentityRole> roleManager;
        public Admin(UserManager<IdentityUser> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            roleManager = _roleManager;
        }

        public async Task Create(string name)
        {
            bool isExist = await roleManager.RoleExistsAsync(name);
            if (!isExist)
            {
                var role = new IdentityRole();
                role.Name = name;
                await roleManager.CreateAsync(role);
            }
        }

        public async Task AddRole(string role, string username)
        {
            IdentityUser user = await userManager.Users.FirstOrDefaultAsync(x => x.UserName == username) as IdentityUser;
            var result = await userManager.AddToRoleAsync(user, role);
        }

        public async Task RemoveRole(string roleName)
        {
            bool exist = await roleManager.RoleExistsAsync(roleName);
            if(exist)
            {
                var role = await roleManager.FindByNameAsync(roleName);
                await roleManager.DeleteAsync(role);
            }
        }

        public async Task<List<IdentityUser>> GetUsers()
        {
            List<IdentityUser> ColUsers = new List<IdentityUser>();
            // get users from _UserManager
            var user = userManager.Users.Select(x => new IdentityUser
            {
                Id = x.Id,
                UserName = x.UserName,
                Email = x.Email,
                PasswordHash = "*****"
            });
            foreach (var item in user)
            {
                ColUsers.Add(item);
            }

            return ColUsers;
        }
    }
}

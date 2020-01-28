using HueSite.Areas.Identity.Data;
using HueSite.Data.IServices;
using HueSite.Data.Models;
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

        UserManager<AppUser> userManager;
        RoleManager<IdentityRole> roleManager;
        public Admin(UserManager<AppUser> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            roleManager = _roleManager;
        }

        public async Task CreateRole(string name)
        {
            bool isExist = await roleManager.RoleExistsAsync(name);
            if (!isExist)
            {
                var role = new IdentityRole();
                role.Name = name;
                await roleManager.CreateAsync(role);
            }
        }

        public async Task AssignRole(string role, string username)
        {
            AppUser user = await userManager.Users.FirstOrDefaultAsync(x => x.UserName == username) as AppUser;
            var result = await userManager.AddToRoleAsync(user, role);
        }

        public async Task UnAssignRole(string role, string username)
        {
            AppUser user = await userManager.Users.FirstOrDefaultAsync(x => x.UserName == username) as AppUser;
            var result = await userManager.RemoveFromRoleAsync(user, role);
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

        public async Task<List<IdentityRole>> GetRoles()
        {
            return roleManager.Roles.ToList();
        }

        public async Task<List<AppUser>> GetUsers()
        {
            return userManager.Users.ToList();
        }

        public async Task<List<DisplayUser>> CreateDisplayUsers(List<AppUser> users)
        {
            List<DisplayUser> Display = new List<DisplayUser>();
            foreach (var x in users)
            {
                var roles = await userManager.GetRolesAsync(x);
                Display.Add(new DisplayUser
                {
                    Email = x.Email,
                    Id = x.Id,
                    UserName = x.UserName,
                    Roles = roles
                });
            }

            return Display;
        }

        public async Task RemoveUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            await userManager.DeleteAsync(user);
        }
    }

}

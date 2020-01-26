using HueSite.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HueSite.Data.IServices
{
    interface IAdmin
    {
        Task CreateRole(string name);
        Task AssignRole(string role, string username);
        Task UnAssignRole(string role, string username);
        Task<List<IdentityUser>> GetUsers();
        Task RemoveRole(string roleName);
        Task<List<IdentityRole>> GetRoles();
        Task<List<DisplayUser>> CreateDisplayUsers(List<IdentityUser> users);
        Task RemoveUser(string id);
    }
}
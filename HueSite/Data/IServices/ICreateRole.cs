using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HueSite.Data.IServices
{
    interface IAdmin
    {
        Task Create(string name);
        Task AddRole(string role, string username);
        Task<List<IdentityUser>> GetUsers();
        Task RemoveRole(string roleName);
    }
}


//@attribute [Authorize(Roles = "admin")]
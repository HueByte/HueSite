using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HueSite.Data.IServices;
using Microsoft.EntityFrameworkCore;

namespace HueSite.Data.Services
{
    public class UserValidate : IValidateUser
    {
        DbContext context;
        public UserValidate(DbContext _context)
        {
            context = _context;
        }
    }
}

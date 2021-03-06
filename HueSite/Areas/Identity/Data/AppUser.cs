﻿using HueSite.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HueSite.Areas.Identity.Data
{
    public class AppUser : IdentityUser
    {
        [PersonalData]
        public byte[] Avatar { get; set; }
        [PersonalData]
        public string Nickname { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public string SelectedTheme { get; set; }
    }
}

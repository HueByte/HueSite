﻿using HueSite.Data.IServices.INotes;
using HueSite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HueSite.Data.Services.Notes
{
    public class Notes : INotes
    {
        DatabaseContext db;
        public Notes(DatabaseContext context)
        {
            db = context;
        }

        public async Task<List<Note>> GetNotesByUserID(string ID)
        {
            return db.Notes.Where(id => id.UserId == ID).ToList();
        }
    }
}

using HueSite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HueSite.Data.IServices.INotes
{
    interface INotes
    {
        public Task<List<Note>> GetNotesByUserID(string ID);
        public Task DeleteNoteById(string ID);
        public Task CreateNote(Note newNote);
    }
}

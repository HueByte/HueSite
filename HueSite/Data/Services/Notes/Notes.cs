using HueSite.Data.IServices.INotes;
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

        public async Task CreateNote(Note newNote)
        {
            await db.Notes.AddAsync(newNote);
            await db.SaveChangesAsync();
        }

        public Task<Note> GetNoteByID(string ID)
        {
            return Task.FromResult(db.Notes.FirstOrDefault(note => note.Id == ID));
        }

        public async Task DeleteNoteById(string ID)
        {
            var RecordToDelete = db.Notes.FirstOrDefault(note => note.Id == ID);

            if (RecordToDelete != null)
            {
                db.Remove(RecordToDelete);
                await db.SaveChangesAsync();
            }
            else { }
        }

        public async Task<bool> UpdateNote(Note updated)
        {
            try
            {
                db.Notes.Update(updated);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

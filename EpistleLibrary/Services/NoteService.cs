using EpistleLibrary.Data;
using EpistleLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EpistleLibrary.Services
{
    public class NoteService
    {
        public static List<NoteModel> GetNotes()
        {
            List<NoteModel> notes = new List<NoteModel>();

            return notes;
        }

        public static void AddNote(NoteModel note)
        {
            using(EpistleContext context = new())
            {
                context.Entry(note).State = EntityState.Unchanged;

                context.Notes.Add(note);

                context.SaveChanges();
            }
        }

        public static int GetNoteCount()
        {
            return 0;
        }
    }
}

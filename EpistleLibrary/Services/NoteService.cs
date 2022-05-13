using EpistleLibrary.Data;
using EpistleLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EpistleLibrary.Services
{
    public class NoteService
    {
        /// <summary>Gets a list of the user's notes</summary>
        /// <returns>A list of the user's notes</returns>
        public static List<NoteModel> GetNotes(string username)
        {
            List<NoteModel> notes = new List<NoteModel>();

            using (EpistleContext context = new())
            {
                foreach (var note in context.Notes.Where(x => x.User.Username == username))
                {
                    notes.Add(note);
                }
            }

            // sort list newest -> oldest
            notes.Sort((x, y) => DateTime.Compare(y.DateCreated, x.DateCreated));
            return notes;
        }

        /// <summary>Creates or updates the note in the database</summary>
        /// <param name="note">Note contains a Title, Content, Date Created, and User</param>
        public static void AddNote(NoteModel note)
        {
            // note title is just the first word, neccessary for sorting purposes
            note.Title = note.Content.Split(' ')[0];

            using (EpistleContext context = new())
            {
                try
                {
                    context.Entry(note).State = EntityState.Unchanged;
                    context.Notes.Update(context.Notes.Where(x => x.Id == note.Id).FirstOrDefault());
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    context.Entry(note).State = EntityState.Unchanged; // https://stackoverflow.com/questions/29721538/violation-of-primary-key-entity-framework-code-first
                    context.Notes.Add(note);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>Loads the given note into the textarea</summary>
        /// <returns>The specified note</returns>
        public static NoteModel LoadNote(NoteModel note)
        {
            using (EpistleContext context = new())
            {
                note = context.Notes.FirstOrDefault(x => x.Id == note.Id);
            }

            return note;
        }

        /// <summary>Deletes a note from the database with the matching Id</summary>
        public static void DeleteNote(NoteModel note)
        {
            using (EpistleContext context = new())
            {
                context.Notes.Remove(context.Notes.FirstOrDefault(x => x.Id == note.Id));
                context.SaveChanges();
            }
        }

        /// <summary>Attatches a note to a bookshelf</summary>
        public static void AddToShelf(NoteModel note)
        {
            using (EpistleContext context = new())
            {
                try
                {
                    context.Notes.Update(note);
                    context.SaveChanges();
                }
                catch(Exception)
                { }
            }
        }
    }
}

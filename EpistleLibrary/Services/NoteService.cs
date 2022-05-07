﻿using EpistleLibrary.Data;
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
            notes.Sort((x, y) => DateTime.Compare(x.DateCreated, y.DateCreated));
            return notes;
        }

        /// <summary>Creates the note in the database</summary>
        /// <param name="note">Note contains a Title, Content, Date Created, and User</param>
        public static void AddNote(NoteModel note)
        {
            // note title is just the first word, neccessary for sorting purposes
            note.Title = note.Content.Split(' ')[0];

            using (EpistleContext context = new())
            {
                context.Entry(note).State = EntityState.Unchanged; // https://stackoverflow.com/questions/29721538/violation-of-primary-key-entity-framework-code-first
                context.Notes.Add(note);
                context.SaveChanges();
            }
        }

        /// <summary>Gets the amount of notes a given user currently has created</summary>
        /// <returns>An integer representing the amount of notes the user has</returns>
        public static NoteModel LoadNote(NoteModel note)
        {
            using (EpistleContext context = new())
            {
                note = context.Notes.FirstOrDefault(x => x.Title == note.Title && x.DateCreated == note.DateCreated);
            }

            return note;
        }
    }
}

using EpistleLibrary.Data;
using EpistleLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EpistleLibrary.Services
{
    public class BookshelfService
    {
        /// <summary>Gets a list of the user's bookshelves</summary>
        /// <returns>A list of the user's bookshelves</returns>
        public static List<BookshelfModel> GetBookshelves(string username)
        {
            List<BookshelfModel> bookshelves = new List<BookshelfModel>();

            using (EpistleContext context = new())
            {
                foreach(var bookshelf in context.Bookshelves.Where(x => x.User.Username == username))
                {
                    bookshelves.Add(bookshelf);
                }
            }

            return bookshelves;
        }

        public static void CreateBookshelf(BookshelfModel bookshelf)
        {
            using(EpistleContext context = new())
            {
                try
                {
                    context.Entry(bookshelf).State = EntityState.Unchanged;
                    context.Bookshelves.Add(bookshelf);
                    context.SaveChanges();
                }
                catch (Exception)
                { }
            }
        }

        public static void DeleteBookshelf(BookshelfModel bookshelf)
        {
            using (EpistleContext context = new())
            {
                try
                {
                    context.Bookshelves.Remove(bookshelf);
                    context.SaveChanges();
                }
                catch (Exception)
                { }
            }
        }
    }
}

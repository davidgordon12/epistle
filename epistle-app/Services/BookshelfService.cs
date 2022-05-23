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
                foreach (var bookshelf in context.EpistleBookshelves.Where(x => x.User.Username == username))
                {
                    bookshelves.Add(bookshelf);
                }
            }

            return bookshelves;
        }

        public static BookshelfModel GetShelf(string title)
        {
            using (EpistleContext context = new())
            {
                BookshelfModel bookshelf = context.EpistleBookshelves.Where(x => x.Title == title).FirstOrDefault();

                return bookshelf;
            }
        }

        public static string CreateBookshelf(BookshelfModel bookshelf)
        {
            using (EpistleContext context = new())
            {
                if(context.EpistleBookshelves.Contains(context.EpistleBookshelves.Where(x=>x.Title==bookshelf.Title).FirstOrDefault()))
                {
                    return "Cannot have duplicate bookshelves";
                }

                context.Entry(bookshelf).State = EntityState.Unchanged;
                context.EpistleBookshelves.Add(bookshelf);
                context.SaveChanges();
                return string.Empty;
            }
        }

        public static void DeleteBookshelf(BookshelfModel bookshelf)
        {
            using (EpistleContext context = new())
            {
                context.EpistleBookshelves.Remove(bookshelf);
                context.SaveChanges();
            }
        }
    }
}

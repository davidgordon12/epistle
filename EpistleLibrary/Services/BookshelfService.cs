using EpistleLibrary.Data;
using EpistleLibrary.Models;

namespace EpistleLibrary.Services
{
    public class BookshelfService
    {
        /// <summary>Gets a list of the user's bookshelves</summary>
        /// <returns>A list of the user's bookshelves</returns>
        public static List<BookshelfModel> GetBookshelves(string username)
        {
            List<BookshelfModel> bookshelves = new List<BookshelfModel>();

            bookshelves.Add(new BookshelfModel
            {
                Title = "Ideas"
            });
            bookshelves.Add(new BookshelfModel
            {
                Title = "Work"
            });

            using (EpistleContext context = new())
            {
                var user = context.Users.Where(x=>x.Username == username).FirstOrDefault();

                /*foreach(var bookshelf in user.Bookshelves)
                {
                    bookshelves.Add(bookshelf);
                }*/
            }

            return bookshelves;
        }
    }
}

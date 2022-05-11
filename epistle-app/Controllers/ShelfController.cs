using EpistleLibrary.Models;
using EpistleLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace epistle_app.Controllers
{
    public class ShelfController : Controller
    {
        public IActionResult Index()
        {
            var user = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Session"));
            ViewBag.Username = user.Username;

            return View(new NoteModel
            {
                Content = ""
            });
        }

        public IActionResult CreateShelf(BookshelfModel bookshelf)
        {
            bookshelf.User = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Session"));

            BookshelfService.CreateBookshelf(bookshelf);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteShelf(BookshelfModel bookshelf)
        {
            bookshelf.User = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Session"));

            BookshelfService.DeleteBookshelf(bookshelf);

            return RedirectToAction("Index");
        }

        public IActionResult AddShelf(BookshelfModel bookshelf)
        {
            return RedirectToAction("Index");
        }

        public IActionResult LoadShelf(BookshelfModel bookshelf)
        {
            return RedirectToAction("Index");
        }
    }
}

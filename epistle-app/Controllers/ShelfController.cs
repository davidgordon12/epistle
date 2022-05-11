using EpistleLibrary.Models;
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

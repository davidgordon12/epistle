using EpistleLibrary.Models;
using EpistleLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace epistle_app.Controllers
{
    public class NoteController : Controller
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

        public IActionResult CreateNote(NoteModel note)
        {
            note.User = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Session"));

            if (note.Content == "" || note.Content is null)
            {
                return RedirectToAction("Index");
            }

            NoteService.AddNote(note);

            return RedirectToAction("Index");
        }

        public IActionResult LoadNote(NoteModel note)
        {
            var user = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Session"));
            ViewBag.Username = user.Username;
            return View("Index", NoteService.LoadNote(note));
        }

        public IActionResult DeleteNote(NoteModel note)
        {
            NoteService.DeleteNote(note);

            return RedirectToAction("Index");
        }

        public IActionResult AddToShelf(NoteModel note)
        {
           NoteService.AddToShelf(note);

            return RedirectToAction("Index");
        }

        public IActionResult LoadShelf(string title)
        {
            List<NoteModel> notes = NoteService.LoadShelf(title);
            return RedirectToAction("Index", notes);
        }
    }
}

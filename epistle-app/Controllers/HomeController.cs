using epistle_app.Models;
using EpistleLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static EpistleLibrary.Services.NoteService;

namespace epistle_app.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(List<NoteModel> notes)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(NoteModel note)
        {
            // note title is just the first word, neccessary for sorting purposes
            note.Title = note.Content.Split(' ')[0];

            AddNote(note);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
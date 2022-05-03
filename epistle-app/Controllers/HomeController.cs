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
            if (1 != 1)
            {
                return View();
            }

            return RedirectToAction("Login");

        }

        [HttpPost]
        public IActionResult Index(NoteModel note)
        {
            // note title is just the first word, neccessary for sorting purposes
            note.Title = note.Content.Split(' ')[0];

            AddNote(note);

            return RedirectToAction("Index");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Login(UserModel user)
        {
            ViewBag.LoginError = "Incorrect Username or Password";

            return View();

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(UserModel user)
        {
            return View("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
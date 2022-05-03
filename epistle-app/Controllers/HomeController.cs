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
        public IActionResult Login(UserModel user)
        {
            if(1 != 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.LoginError = "Incorrect username or password";
                return View();
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserModel user)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            ViewBag.SignupError = "One or more fields were incorrect";
            return View("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
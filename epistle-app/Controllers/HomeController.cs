using epistle_app.Models;
using EpistleLibrary.Models;
using EpistleLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static EpistleLibrary.Services.NoteService;

namespace epistle_app.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(List<NoteModel> notes)
        {
            return View("Login");
        }

        [HttpPost]
        public IActionResult Index(NoteModel note)
        {
            // note title is just the first word, neccessary for sorting purposes
            note.Title = note.Content.Split(' ')[0];

            AddNote(note);

            return View("Index");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(_LoginModel login)
        {
            if(UserService.GetUser(login.Username, login.Password) != string.Empty)
            {
                ViewBag.Username = login.Username;
                return View("Index");
            }
            else
            {
                ViewBag.LoginError = "Incorrect Username or Password";
                return View();
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(_UserModel user)
        {
            if(UserService.CreateUser(user.Username, user.Password))
            {
                return View("Login");
            }
            else
            {
                ViewBag.SignupError = "This username is already taken";
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
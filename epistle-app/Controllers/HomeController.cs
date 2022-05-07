using epistle_app.Models;
using EpistleLibrary.Models;
using EpistleLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace epistle_app.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var user = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Session"));
            ViewBag.Username = user.Username;
            return View();
        }

        [HttpGet]
        public IActionResult Index(NoteModel note)
        {
            var user = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Session"));
            ViewBag.Username = user.Username;
            return View(note);
        }

        [HttpPost]
        public IActionResult Index(NoteModel note, bool? post)
        {
            if(note.Content == "" || note.Content is null)
            {
                return View();
            }

            var user = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Session"));

            note.User = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("Session"));
            NoteService.AddNote(note);

            ViewBag.Username = user.Username;

            return View("Index");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(_LoginModel login)
        {
            if (UserService.GetUser(login.Username, login.Password) == string.Empty)
            {
                ViewBag.LoginError = "Incorrect Username or Password";
                return View();
            }

            HttpContext.Session.SetString("Session", JsonConvert.SerializeObject(login));

            ViewBag.Username = login.Username;

            return View("Index");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return View("Login");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(_UserModel user)
        {
            if (UserService.CreateUser(user.Username, user.Password, user.Email))
            {
                return View("Login");
            }
            else
            {
                ViewBag.SignupError = "This username is already taken";
                return View();
            }
        }

        public ActionResult LoadNote(NoteModel note)
        {
            NoteService.LoadNote(note);

            return RedirectToAction("Index", note);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
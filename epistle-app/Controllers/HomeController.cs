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
            return View(new NoteModel
            {
                Content = ""
            });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
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

            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return View("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
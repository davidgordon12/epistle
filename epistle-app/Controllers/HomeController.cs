using epistle_app.Models;
using EpistleLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace epistle_app.Controllers
{
    public class NoteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

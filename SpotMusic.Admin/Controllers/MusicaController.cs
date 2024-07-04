using Microsoft.AspNetCore.Mvc;

namespace SpotMusic.Admin.Controllers
{
    public class MusicaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

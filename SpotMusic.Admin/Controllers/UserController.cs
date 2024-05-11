using Microsoft.AspNetCore.Mvc;

namespace SpotMusic.Admin.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

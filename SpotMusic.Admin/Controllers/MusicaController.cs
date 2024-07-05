using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpotMusic.Application.Streaming;

namespace SpotMusic.Admin.Controllers
{
    [Authorize]
    public class MusicaController(MusicaService musicaService) : Controller
    {
        public IActionResult Index(Guid IdAutor)
        {
            var result = musicaService.ObterMusicas(IdAutor);

            return View(result);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpotMusic.Application.Streaming;
using SpotMusic.Application.Streaming.Dto;

namespace SpotMusic.Admin.Controllers
{
    [Authorize]
    public class AutorController(AutorService _AutorService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var result = await _AutorService.Obter();

            return View(result);
        }


        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(AutorDto dt)
        {
            if (ModelState.IsValid == false)
            {
                return View("Criar");
            }

            await _AutorService.Salvar(dt);

            return RedirectToAction("Index");
        }
    }
}

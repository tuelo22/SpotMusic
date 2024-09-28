using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SpotMusic.Application.Streaming;
using SpotMusic.Application.Streaming.Dto;

namespace SpotMusic.Admin.Controllers
{
    [Authorize]
    public class MusicaController(MusicaService musicaService, EstiloMusicalService estiloMusicalService, AutorService autorService) : Controller
    {
        public async Task<IActionResult> Index(Guid IdAutor)
        {
            var result = musicaService.ObterMusicas(IdAutor);

            var autor = await autorService.Obter(IdAutor);

            ViewBag.AutorNome = autor?.Nome ?? string.Empty;

            ViewBag.IdAutor = IdAutor;

            return View(result);
        }

        public async Task<IActionResult> Criar(Guid IdAutor)
        {
            var result = estiloMusicalService.Obter();

            ViewBag.IdAutor = IdAutor;

            var autor = await autorService.Obter(IdAutor);

            ViewBag.AutorNome = autor?.Nome ?? string.Empty;

            ViewBag.Estilos = new SelectList(result, "Id", "Nome");

            return View();
        }

        [HttpPost]
        public IActionResult Salvar(MusicaDto dt)
        {
            if (ModelState.IsValid == false)
            {
                return View("Criar");
            }

            musicaService.Salvar(dt);

            return RedirectToAction("Index", new { IdAutor = dt.IdAutor});
        }
    }
}

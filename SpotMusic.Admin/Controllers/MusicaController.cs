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
        public IActionResult Index(Guid IdAutor)
        {
            var result = musicaService.ObterMusicas(IdAutor);

            ViewBag.AutorNome = autorService.Obter(IdAutor)?.Nome ?? string.Empty;

            ViewBag.IdAutor = IdAutor;

            return View(result);
        }

        public IActionResult Criar(Guid IdAutor)
        {
            var result = estiloMusicalService.Obter();

            ViewBag.IdAutor = IdAutor;

            ViewBag.AutorNome = autorService.Obter(IdAutor)?.Nome ?? string.Empty;

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

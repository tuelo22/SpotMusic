using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SpotMusic.Application.Streaming;
using SpotMusic.Application.Streaming.Dto;
using SpotMusic.Domain.Streaming.Aggregates;

namespace SpotMusic.Admin.Controllers
{
    [Authorize]
    public class AlbumController(AlbumService albumService, AutorService autorService, MusicaService musicaService ) : Controller
    {
        public async Task<IActionResult> Index(Guid? IdAutor)
        {
            List<AlbumDto> albums = [];

            if(IdAutor != null)
            {
                albums = albumService.ObterPorAutor(IdAutor.Value);

                var autor = await autorService.Obter(IdAutor.Value);

                ViewBag.IdAutor = IdAutor.Value;

                ViewBag.AutorNome = autor?.Nome;
            }
            else
            {
                albums = albumService.ObterTodos();
            }

            return View(albums);
        }

        public IActionResult Criar(Guid IdAutor)
        {
            ViewBag.IdAutor = IdAutor;

            var result = musicaService.ObterMusicasSemAlbum(IdAutor);

            ViewBag.Musicas = new SelectList(result, "Id", "Nome");

            return View();
        }

        public IActionResult AdicionarMusica(Guid IdAlbum)
        {
            var album = albumService.Obter(IdAlbum);

            ViewBag.IdAlbum  = IdAlbum;
            ViewBag.IdAutor  = album?.IdAutorPrincipal;
            ViewBag.AutorNome = album?.NomeAutorPrincipal;
            ViewBag.NomeAlbum = album?.Nome;

            List<MusicaDto> musicas = [];

            if(album?.IdAutorPrincipal != null)
            {
                musicas = musicaService.ObterMusicasSemAlbum(album.IdAutorPrincipal);
            }

            ViewBag.MusicasSemAlbum = new SelectList(musicas, "Id", "Nome");

            return View();
        }

        [HttpPost]
        public IActionResult Salvar(AlbumDto dt)
        {
            if (ModelState.IsValid == false)
            {
                return View("Criar");
            }

            albumService.Salvar(dt);

            return RedirectToAction("Index", new { IdAutor = dt.IdAutorPrincipal });
        }

        [HttpPost]
        public IActionResult AdicionarMusica(AdicionarMusicaDto dt)
        {
            if (ModelState.IsValid == false)
            {
                return View("AdicionarMusica");
            }

            albumService.AdicionarMusica(dt);

            return RedirectToAction($"AdicionarMusica", new { IdAlbum = dt.IdAlbum });
        }
    }
}

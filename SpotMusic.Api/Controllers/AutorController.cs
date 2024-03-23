using Microsoft.AspNetCore.Mvc;
using SpotMusic.Application.Streaming;
using SpotMusic.Application.Streaming.Dto;

namespace SpotMusic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private AutorService AutorService;
        private AlbumService AlbumService;

        public AutorController(AutorService autorService, AlbumService albumService)
        {
            AutorService = autorService;
            AlbumService = albumService;
        }

        [HttpGet]
        public IActionResult GetAutores()
        {
            var result = AutorService.Obter();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetAutor(Guid id)
        {
            var result = AutorService.Obter(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult SeveAutor([FromBody] AutorDto autor)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = AutorService.Criar(autor);

            return Created($"/autor/{result.Id}", result);
        }

        [HttpPost("{id}/albums")]
        public IActionResult AssociarAlbum(AlbumDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = AlbumService.Criar(dto);

            return Created($"/autor/{result.IdAutorPrincipal}/albums/{dto.Id}", result);
        }

        [HttpGet("{idAutor}/albums/{id}")]
        public IActionResult AssociarAlbum(Guid idAutor, Guid id)
        {
            var result = AlbumService.Obter(idAutor, id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

    }
}

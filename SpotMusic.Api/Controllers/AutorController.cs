using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpotMusic.Application.Streaming;
using SpotMusic.Application.Streaming.Dto;

namespace SpotMusic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
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
        [ProducesResponseType(typeof(List<AutorDto>), 200)]
        public IActionResult GetAutores()
        {
            var result = AutorService.Obter();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AutorDto), 200)]
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

        [HttpGet("{IdUsuario}/albums/{idAutor}")]
        [ProducesResponseType(typeof(List<AlbumDto>), 200)]
        public IActionResult ObterAlbuns(Guid IdUsuario, Guid idAutor)
        {
            var result = AlbumService.ObterPorAutor(idAutor, IdUsuario);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}

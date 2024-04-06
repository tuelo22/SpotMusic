using Microsoft.AspNetCore.Mvc;
using SpotMusic.Application.Streaming;
using SpotMusic.Application.Streaming.Dto;

namespace SpotMusic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicaController : ControllerBase
    {
        private readonly MusicaService musicaService;

        public MusicaController(MusicaService musicaService)
        {
            this.musicaService = musicaService;
        }

        [HttpGet("{IdUsuario}/buscar/{texto}")]
        [ProducesResponseType(typeof(List<MusicaDto>), 200)]
        public IActionResult buscar(Guid IdUsuario, String texto)
        {
            var result = musicaService.BuscarMusica(IdUsuario, texto);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("adicionarfavorito")]
        [ProducesResponseType(typeof(MusicaDto), 200)]
        public IActionResult adicionarfavorito(FavoritarMusicaDto dto)
        {
            var result = musicaService.FavoritarMusica(dto.UsuarioId, dto.MusicaId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{IdUsuario}/favoritas")]
        [ProducesResponseType(typeof(List<MusicaDto>), 200)]
        public IActionResult favoritas(Guid IdUsuario)
        {
            var result = musicaService.favoritas(IdUsuario);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using SpotMusic.Api.Controllers.Request;
using SpotMusic.Application.Conta;
using SpotMusic.Application.Conta.Request;

namespace SpotMusic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase 
    {
        private UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            this._usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult Criar(UsuarioDto usuario)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._usuarioService.Criar(usuario);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Obter(Guid id)
        {
            var result = this._usuarioService.Obter(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("/login")]
        public IActionResult login(LoginRequeste login) 
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._usuarioService.Autenticar(login.Email, login.Senha);

            if (result == null)
                return BadRequest(new { Error = "Dados incorretos."});

            return Ok(result);

        }

        [HttpGet("ObterPlanos")]
        public IActionResult ObterPlanos()
        {
            var result = this._usuarioService.ObterPlanos();

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}

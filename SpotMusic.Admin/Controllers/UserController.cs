using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpotMusic.Application.Admin;
using SpotMusic.Application.Admin.Dto;

namespace SpotMusic.Admin.Controllers
{
    [Authorize]
    public class UserController(UsuarioAdminService usuarioAdminService) : Controller
    {
        public IActionResult Index()
        {
            var result = usuarioAdminService.ObterTodos();

            return View(result);
        }

        [AllowAnonymous]
        public IActionResult Criar() 
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Salvar(UsuarioAdminDto dt) 
        {
            if(ModelState.IsValid == false)
            {
                return View("Criar");
            }
            
            usuarioAdminService.Salvar(dt);

            return RedirectToAction("Index");
        }
    }
}

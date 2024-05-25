using Microsoft.AspNetCore.Mvc;
using SpotMusic.Application.Admin;
using SpotMusic.Application.Admin.Dto;

namespace SpotMusic.Admin.Controllers
{
    public class UserController(UsuarioAdminService usuarioAdminService) : Controller
    {
        public IActionResult Index()
        {
            var result = usuarioAdminService.ObterTodos();

            return View(result);
        }

        public IActionResult Criar() 
        {
            return View();
        }

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

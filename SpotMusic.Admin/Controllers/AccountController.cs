using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpotMusic.Application.Admin;
using System.Security.Claims;

namespace SpotMusic.Admin.Controllers
{
    public class AccountController(UsuarioAdminService usuarioAdminService) : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(SpotMusic.Admin.Models.LoginRequest request)
        {
            if (ModelState.IsValid == false)
                return View();

            var user = usuarioAdminService.Autenticate(request.Email, request.Senha);

            if (user == null)
            {
                ModelState.AddModelError("Erro_login", "Email ou senha incorreta.");

                return View();
            }

            var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Nome));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}

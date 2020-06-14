using Grupo4.InstitutoEducativo.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UsandoEntityFramework.Database;

namespace Grupo4.InstitutoEducativo.Controllers
{
    public class CuentasController : Controller
    {
        private readonly UsandoEFDbContext _context;
        public CuentasController(UsandoEFDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Ingresar(string returnUrl)
        {
            // Url de retorno
            ViewBag.ReturnUrl = returnUrl;
            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Ingresar(string username, string password, string returnUrl)
        {
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                Usuario usuario = _context.Profesor.FirstOrDefault(usr => usr.Username == username);
                if(usuario == null)
                {
                    usuario = _context.Alumno.FirstOrDefault(usr => usr.Username == username);
                }
                if (usuario != null)
                {
                    byte[] passwordEncriptada = new SHA256Managed().ComputeHash(Encoding.ASCII.GetBytes(password));

                    if (usuario.Password.SequenceEqual(passwordEncriptada))
                    {
                        // Se crean las credenciales del usuario que serán incorporadas al contexto
                        ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                        // El lo que luego obtendré al acceder a User.Identity.Name
                        identity.AddClaim(new Claim(ClaimTypes.Name, username));
                        // Se utilizará para la autorización por roles
                        identity.AddClaim(new Claim(ClaimTypes.Role, usuario.Role.ToString()));
                        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()));

                        ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                        // En este paso se hace el login del usuario al sistema
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                        // Guardo la fecha de último acceso que es ahora.
                        usuario.FechaUltimoAcceso = DateTime.Now;
                        _context.SaveChanges();

                        if (!string.IsNullOrWhiteSpace(returnUrl))
                            return Redirect(returnUrl);

                        TempData["primerLogin"] = true;

                        return RedirectToAction(nameof(HomeController.Index), "Home");
                    }
                }
            }
            // Completo estos dos campos para poder retornar a la vista en caso de errores.
            ViewBag.Error = "Usuario o contraseña incorrectos";
            ViewBag.UserName = username;
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        public IActionResult NoAutorizado()
        {
            return View();
        }
    }
}

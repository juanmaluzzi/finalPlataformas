using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using plataformasGrupo5TPFinal.Data;
using plataformasGrupo5TPFinal.Models;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Security.Principal;
using plataformasGrupo5TPFinal.Helpers;

namespace plataformasGrupo5TPFinal.Controllers
{
    public class LoginController : Controller
    {
        [BindProperty]
        public Usuario User { get; set; }
        private int intentos { get; set; }


        private readonly UserContext _context;

        public LoginController(UserContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,dni,nombre,mail,password,esAdmin,bloqueado,intentos")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(int dni, string password)
        {

            if (!ModelState.IsValid)
            {
                /* return BadRequest(new JObject() {
                     { "StatusCode", 400 },
                     { "Message", "El usuario ya existe, seleccione otro." }
                 });
                */
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var result = await _context.Usuario.Where(u => u.dni == User.dni).FirstOrDefaultAsync();
                
                if (result == null)
                {
                    //Usuario no encontrado
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme,
                            ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, result.id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, result.nombre));
                identity.AddClaim(new Claim("dni", result.dni.ToString()));
                identity.AddClaim(new Claim("mail", result.mail));
                identity.AddClaim(new Claim("admin", result.esAdmin.ToString()));
                identity.AddClaim(new Claim("bloqueado", result.bloqueado.ToString()));
                identity.AddClaim(new Claim("intentos", result.intentos.ToString()));

                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    principal,
                    new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.Now.AddSeconds(3600),
                        IsPersistent = false
                    });

                    if (User.password == result.password)
                    {
                        Console.WriteLine("Password ok");

                        if (result.bloqueado)
                        {
                            Console.WriteLine("User bloqueado");
                            return RedirectToAction("Index", "Login");
                        }
                        else
                        {
                            Console.WriteLine("User ok");
                            if (result.esAdmin)
                            {
                                return RedirectToAction("Abm", "My");
                            }
                            else
                            {
                                return RedirectToAction("Buscador", "My");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Password erronea");
                        SumarIntentos(result.id);
                        Console.WriteLine("Intentos: "+result.intentos);
                        if (result.intentos == 3)
                        {
                            Console.WriteLine("Usuario bloqueado");
                            BloqueoUsuario(result.id);
                            return RedirectToAction("Index", "Login");
                        }
                        //Usuario o contraseña no válida" 
                        return RedirectToAction("Index", "Login");
                    }
                }
            }
        }

        public bool BloqueoUsuario(int id)
        {

            if (ModelState.IsValid)
            {
                Usuario usuario = _context.Usuario.Where(u => u.id == id).FirstOrDefault();
                usuario.bloqueado = true;
                usuario.intentos = 0;
                _context.Update(usuario);
                _context.SaveChanges();
                return true;
            }

            return false;

        }
        public bool SumarIntentos(int id)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = _context.Usuario.Where(u => u.id == id).FirstOrDefault();
                usuario.intentos = usuario.intentos + 1;
                _context.Update(usuario);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Login");
        }
    }
}

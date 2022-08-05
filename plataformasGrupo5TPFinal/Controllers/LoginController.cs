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
                var result = await _context.Usuario.Where(u => u.dni == User.dni).FirstOrDefaultAsync();
                
                if (result == null)
                {
                    //Usuario NO EXISTE
                    usuario.password = Encrypt.GetSHA265(usuario.password);
                    _context.Add(usuario);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["errorSignIn"] = "El documento ingresado ya existe";
                    return View("SignIn");
                }

            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(int dni, string password)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var result = await _context.Usuario.Where(u => u.dni == User.dni).FirstOrDefaultAsync();
                
                if (result == null)
                {
                    //Usuario NO EXISTE
                    ViewData["Mensaje"] = "Usuario y/o contraseña invalidos";
                    return View("Index");
                }
                else
                {
                    User.password = Encrypt.GetSHA265(password);
                    if (User.password == result.password)
                    {
                        //Usuario autenticado correctamente
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

                        if (result.bloqueado)
                        {
                            //Usuario BLOQUEADO
                            ViewData["Mensaje"] = "El usuario se encuentra bloqueado";
                            return View("Index");
                        }
                        else
                        {
                            if (result.esAdmin)
                            {
                                //Usuario logueado es ADMIN
                                return RedirectToAction("Abm", "My");
                            }
                            else
                            {
                                //Usuario logueado es NO ES ADMIN
                                return RedirectToAction("Buscador", "Alojamientos");
                            }
                        }
                    }
                    else
                    {
                        SumarIntentos(result.id);
                        
                        if (result.intentos == 3)
                        {
                            //Usuario se HA BLOQUEADO
                            ViewData["Mensaje"] = "Se ha bloqueado el usuario";
                            BloqueoUsuario(result.id);
                            return View("Index");
                        }
                        //Usuario o contraseña no válida" 
                        ViewData["Mensaje"] = "Usuario y/o contraseña invalidos";
                        return View("Index");
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
                usuario.intentos++;
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

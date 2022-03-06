using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using plataformasGrupo5TPFinal.Data;
using plataformasGrupo5TPFinal.ViewModels;
using plataformasGrupo5TPFinal.Helpers;

namespace plataformasGrupo5TPFinal.Models
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly UserContext _context;

        public UsuariosController(UserContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuario.ToListAsync());
        }

        public async Task<IActionResult> UserProfile(int id)
        {
            return View(await _context.Usuario.Where(u => u.id == id).FirstOrDefaultAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,dni,nombre,mail,password,esAdmin,bloqueado,intentos")] Usuario usuario)
        {
            if (id != usuario.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.id == id);
        }

        public List<Reservas> ReservasUsuario(int dni)
        {
            List<Reservas> reservas = _context.Reservas.Where(res => res.dniPersona == dni).ToList();
            return reservas;
        }

        [HttpGet]
        [Route("Usuarios/CambiarPassword")]
        public IActionResult CambiarPassword()
        {
            return View();
        }

        [HttpPost]
        [Route("Usuarios/CambiarPassword")]
        public async Task<IActionResult> CambiarPassword(CambioPasswordViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _context.Usuario.FindAsync(int.Parse(SessionsHelpers.GetNameIdentifier(User).ToString()));
                if (usuario == null)
                {
                    return RedirectToAction("Login");
                }

                var result = ChangePassword(usuario, modelo.PasswordActual, modelo.NuevaPassword);

                if (!result)
                {
                    return View();
                }
                else { 
                    return RedirectToAction("UserProfile");
                }
            }
            return View(modelo);
        }

        public bool ChangePassword(Usuario user, string passwordActual, string nuevaPassword)
        {
            if (user.password.Equals(passwordActual))
            {
                user.password = nuevaPassword;
                _context.Update(user);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

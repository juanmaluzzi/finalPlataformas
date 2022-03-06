using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using plataformasGrupo5TPFinal.Data;
using plataformasGrupo5TPFinal.Helpers;
using plataformasGrupo5TPFinal.ViewModels;

namespace plataformasGrupo5TPFinal.Models
{
    [Authorize]
    public class ReservasController : Controller
    {
        public readonly UserContext _context;

        public ReservasController(UserContext context)
        {
            _context = context;
        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reservas.ToListAsync());
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservas = await _context.Reservas
                .FirstOrDefaultAsync(m => m.id == id);
            if (reservas == null)
            {
                return NotFound();
            }

            return View(reservas);
        }

        // GET: Reservas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reservas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,fDesde,fHasta,codAlojamiento,dniPersona,precio")] Reservas reservas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservas);
        }

        // GET: Reservas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservas = await _context.Reservas.FindAsync(id);
            if (reservas == null)
            {
                return NotFound();
            }
            return View(reservas);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,fDesde,fHasta,codAlojamiento,dniPersona,precio")] Reservas reservas)
        {
            if (id != reservas.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservasExists(reservas.id))
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
            return View(reservas);
        }

        // GET: Reservas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservas = await _context.Reservas
                .FirstOrDefaultAsync(m => m.id == id);
            if (reservas == null)
            {
                return NotFound();
            }

            return View(reservas);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservas = await _context.Reservas.FindAsync(id);
            _context.Reservas.Remove(reservas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservasExists(int id)
        {
            return _context.Reservas.Any(e => e.id == id);
        }
        public async Task<IActionResult> ReservasUsuario(string dni)
        {
            return View(await _context.Reservas.Where(res => res.dniPersona.ToString() == dni).ToListAsync());
        }

        [HttpGet]
        [Route("Reservas/ConfirmarReserva")]
        public IActionResult ConfirmarReserva()
        {
            return View();
        }

        [HttpPost]
        [Route("Reservas/ConfirmarReserva")]
        public async Task<IActionResult> ConfirmarReserva(GestorReservasViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                dynamic mymodel = new ExpandoObject();
                var usuario = await _context.Usuario.FindAsync(int.Parse(SessionsHelpers.GetNameIdentifier(User).ToString()));
                if (usuario == null)
                {
                    return RedirectToAction("Index","Login");
                }
                Alojamiento aloj;
                var cabaña = await _context.Cabaña.FindAsync(int.Parse(modelo.AlojamientoSeleccionado));
                if (cabaña == null)
                {
                    var hotel = await _context.Hotel.FindAsync(int.Parse(modelo.AlojamientoSeleccionado));
                    aloj = hotel;
                }
                else
                {
                    aloj = cabaña;
                }
                mymodel.Alojamiento = aloj;
                mymodel.Usuario = usuario;
                mymodel.fechaDesde = modelo.FechaDesde;
                mymodel.fechaHasta = modelo.FechaHasta;
                
                return View(mymodel);
            }

            return View();
        }

    }
}

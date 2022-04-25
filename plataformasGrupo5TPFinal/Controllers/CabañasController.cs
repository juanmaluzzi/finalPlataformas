using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using plataformasGrupo5TPFinal.Data;

namespace plataformasGrupo5TPFinal.Models
{
    [Authorize]
    public class CabañasController : Controller

    {
        private readonly UserContext _context;

        public CabañasController(UserContext context)
        {
            _context = context;
        }

        // GET: Cabañas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cabaña.ToListAsync());
        }

        // GET: Cabañas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cabaña = await _context.Cabaña
                .FirstOrDefaultAsync(m => m.idCabana == id);
            if (cabaña == null)
            {
                return NotFound();
            }

            return View(cabaña);
        }

        // GET: Cabañas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cabañas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idCabana,precioDia,habitaciones,baños,codigo,nombre,ciudad,barrio,estrellas,cantPersonas,tv")] Cabaña cabaña)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cabaña);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cabaña);
        }

        // GET: Cabañas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cabaña = await _context.Cabaña.FindAsync(id);
            if (cabaña == null)
            {
                return NotFound();
            }
            return View(cabaña);
        }

        // POST: Cabañas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idCabana,precioDia,habitaciones,baños,codigo,nombre,ciudad,barrio,estrellas,cantPersonas,tv")] Cabaña cabaña)
        {
            if (id != cabaña.idCabana)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cabaña);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CabañaExists(cabaña.idCabana))
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
            return View(cabaña);
        }

        // GET: Cabañas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cabaña = await _context.Cabaña
                .FirstOrDefaultAsync(m => m.idCabana == id);
            if (cabaña == null)
            {
                return NotFound();
            }

            return View(cabaña);
        }

        // POST: Cabañas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cabaña = await _context.Cabaña.FindAsync(id);
            _context.Cabaña.Remove(cabaña);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CabañaExists(int id)
        {
            return _context.Cabaña.Any(e => e.idCabana == id);
        }
    }
}

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

        // GET: ReservasUsuario
        [HttpGet]
        [Route("Reservas/ReservasUsuario")]
        public async Task<IActionResult> ReservasUsuario(int? id)
        {
            //List<Reservas> listaReservas = await _context.Reservas.Where(res => res.dniPersona == dni).ToListAsync();
            List<Reservas> listaReservas = await _context.Reservas.ToListAsync();
            listaReservas = listaReservas.FindAll(res => res.dniPersona.Equals(id)).ToList();

            List<Reservas> listaReservasBruto = await _context.Reservas.ToListAsync();
            int cantReservas = listaReservas.Count;
            Console.WriteLine("Dni: "+id);
            Console.WriteLine("Reservas del usuario: "+cantReservas);
            return View(listaReservas);
        }


        //public async Task<IActionResult> ConfirmarReserva(int id)
        //{
        //    Console.WriteLine("Codigo alojamiento: "+id.ToString());
        //    Alojamiento aloj = await _context.Alojamiento.FirstOrDefaultAsync(aloj => aloj.aCodigo == id);
        //    
        //    if(aloj != null)
        //    {
        //        Console.WriteLine("Se encontro alojamiento codigo: " + aloj.ToString());
        //        ViewData["codAloj"] = aloj.aCodigo;
        //        ViewData["tipo"] = aloj.Tipo;
        //        if (aloj.Tipo == "Hotel")
        //        {
        //            ViewData["precio"] = aloj.hPrecioxPersona;
        //        }
        //        else
        //        {
        //            ViewData["precio"] = aloj.cPrecioxDia;
        //        }
        //
        //    }
        //    else
        //    {
        //        Console.WriteLine("No se encontro alojamiento");
        //    }
        //    return View();
        //}
        //
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearReserva([Bind("id,fDesde,fHasta,codAlojamiento,dniPersona,precio")] Reservas reserva)
        {
            Console.WriteLine("fdesde: " + reserva.fDesde);
            Console.WriteLine("fhasta: " + reserva.fHasta);
            Console.WriteLine("precio: " + reserva.precio);
            Console.WriteLine("codAlojamiento: " + reserva.codAlojamiento);
            
            if (ModelState.IsValid)
            {
                int idUser = int.Parse(SessionsHelpers.GetNameIdentifier(User).ToString());
                Console.WriteLine("idUser: " + idUser.ToString());
                reserva.dniPersona = idUser;
                //Reservas reserva = new Reservas(0, fdesde, fhasta, codAlojamiento, idUser, precio);
                try
                {
                    Console.WriteLine("se agrega al contexto");
                    _context.Add(reserva);
                    Console.WriteLine("se agregó al contexto");
                    Console.WriteLine("se guardan los cambios en la db");
                    await _context.SaveChangesAsync();
                    Console.WriteLine("se pudo guardar en la db");
                    return RedirectToAction("ReservasUsuario", new { id = idUser });
                }
                catch(Exception e)
                {
                    ViewData["mensaje"] = "Hubo un error al guardar";
                    ViewData["codAloj"] = reserva.codAlojamiento;
                    Console.WriteLine("no se pudo guardar en la db");
                    return View();
                }
                
            }
            Console.WriteLine("ModelState invalid");
            return View();
        }

        [HttpGet]
        [Route("Reservas/ConfirmarReserva")]
        public IActionResult ConfirmarReserva(int propiedadId, String aTipoElegido, DateTime fDesde, int aCantPersonas, String aTipo, DateTime fHasta, String aCiudad)
        {
            Alojamiento alojElegido = _context.Alojamiento.ToList().FirstOrDefault(aloj => aloj.id == propiedadId);
            float precio = calcularPrecioReserva(alojElegido, fDesde, fHasta, aCantPersonas);

            ViewData["cPrecioxDia"] = 0.0;
            ViewData["hPrecioxPersona"] = 0.0;

            if(alojElegido.Tipo == "Hotel")
            {
                ViewData["hPrecioxPersona"] = alojElegido.hPrecioxPersona;
            }
            else
            {
                ViewData["cPrecioxDia"] = alojElegido.cPrecioxDia;
            }

            ViewData["propiedadId"] = alojElegido.id;
            ViewData["aCantPersonas"] = aCantPersonas;
            ViewData["aTipo"] = aTipo;
            ViewData["aCiudad"] = alojElegido.aCiudad;
            ViewData["aTipoElegido"] = aTipoElegido;

            String dateDesde = fDesde.ToString("yyyy-MM-dd");
            ViewData["fDesde"] = dateDesde;
            String dateHasta = fHasta.ToString("yyyy-MM-dd");
            ViewData["fHasta"] = dateHasta;
            ViewData["precio"] = precio;
            ViewData["fdHasta"] = fHasta;
            ViewData["fdDesde"] = fDesde;
            int idUser = int.Parse(SessionsHelpers.GetNameIdentifier(User).ToString());
            Reservas reserva = new Reservas(0, fDesde, fHasta, alojElegido.aCodigo, idUser, precio);
            return View(reserva);
        }

        public float calcularPrecioReserva(Alojamiento aloj, DateTime fDesde, DateTime fHasta, int cantPersonas)
        {
                Console.WriteLine(aloj.ToString() + "fDesde: "+fDesde.ToString()
                    + "fHasta: " + fHasta.ToString()
                    + "cantPers: " + cantPersonas.ToString());
            float precio = 0;
            var span = fHasta.Date.Subtract(fDesde.Date);
            int dias = span.Days;
            dias = dias + 1;

            if (aloj != null && aloj.Tipo == "Hotel")
            {
                precio = Convert.ToSingle(aloj.hPrecioxPersona * cantPersonas * dias);
            }
            else if (aloj != null)
            {
                precio = Convert.ToSingle(aloj.cPrecioxDia * dias);
            }
            return precio;
        }

    }
}

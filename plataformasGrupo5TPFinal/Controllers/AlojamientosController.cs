using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using plataformasGrupo5TPFinal.Data;
using plataformasGrupo5TPFinal.Models;

namespace plataformasGrupo5TPFinal.Controllers
{
    public class AlojamientosController : Controller
    {
        private readonly UserContext _context;

        public AlojamientosController(UserContext context)
        {
            _context = context;
        }

        // GET: Alojamientos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alojamiento.ToListAsync());
        }

        // GET: Alojamientos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alojamiento = await _context.Alojamiento
                .FirstOrDefaultAsync(m => m.id == id);
            if (alojamiento == null)
            {
                return NotFound();
            }

            return View(alojamiento);
        }

        // GET: Alojamientos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alojamientos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,aCodigo,aCiudad,aBarrio,aEstrellas,aCantPersonas,aTV,Tipo,cPrecioxDia,cHabitaciones,cbanios,hPrecioxPersona")] Alojamiento alojamiento)
        {
            if (ModelState.IsValid)
            {
                int lastId;
                var listAloj = await _context.Alojamiento.ToListAsync();
                if(listAloj.Count == 0) 
                {
                    lastId = 0;
                }else
                {
                    lastId = listAloj.Last().id + 1;
                }

                if(alojamiento.Tipo == "Hotel")
                {
                    //Codigo Hotel 2NNN 
                    alojamiento.aCodigo = 2000 + lastId;
                    alojamiento.cPrecioxDia = 0;
                }
                else
                {
                    //Codigo Cabaña 6NNN 
                    alojamiento.aCodigo = 6000 + lastId;
                    alojamiento.hPrecioxPersona = 0;
                }
                _context.Add(alojamiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alojamiento);
        }

        // GET: Alojamientos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alojamiento = await _context.Alojamiento.FindAsync(id);
            if (alojamiento == null)
            {
                return NotFound();
            }
            return View(alojamiento);
        }

        // POST: Alojamientos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,aCodigo,aCiudad,aBarrio,aEstrellas,aCantPersonas,aTV,Tipo,cPrecioxDia,cHabitaciones,cbanios,hPrecioxPersona")] Alojamiento alojamiento)
        {
            if (id != alojamiento.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alojamiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlojamientoExists(alojamiento.id))
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
            return View(alojamiento);
        }

        // GET: Alojamientos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alojamiento = await _context.Alojamiento
                .FirstOrDefaultAsync(m => m.id == id);
            if (alojamiento == null)
            {
                return NotFound();
            }

            return View(alojamiento);
        }

        // POST: Alojamientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alojamiento = await _context.Alojamiento.FindAsync(id);
            _context.Alojamiento.Remove(alojamiento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlojamientoExists(int id)
        {
            return _context.Alojamiento.Any(e => e.id == id);
        }

        //public async Task<IActionResult> Buscador()
        //{
        //    return View(await _context.Alojamiento.ToListAsync());
        //}

        public async Task<IActionResult> Buscador(String sortOrder, String aCiudad, DateTime fDesde, DateTime fHasta, String aTipo,
           int aCantPersonas, float aPrecioDesde, float aPrecioHasta, int aEstrellas, float rPrecioDesde, float rPrecioHasta)
        {
            ViewBag.PrecioDiaSortParm = sortOrder == "preciodia" ? "preciodiab" : "preciodia";
            ViewBag.PrecioPersonaSortParm = sortOrder == "preciopersona" ? "preciopersonab" : "preciopersona";
            ViewBag.EstrellasSortParm = sortOrder == "estrellas" ? "estrellasb" : "estrellas";
            ViewBag.CapacidadSortParm = sortOrder == "capacidad" ? "capacidadb" : "capacidad";
            ViewBag.PrecioReservaSortParm = sortOrder == "precioreserva" ? "precioreservab" : "precioreserva";

            ViewData["aCantPersonas"] = aCantPersonas;
            ViewData["aTipo"] = aTipo;
            ViewData["aCiudad"] = aCiudad;
            String dateDesde = fDesde.ToString("yyyy-MM-dd");
            ViewData["fDesde"] = dateDesde;
            String dateHasta = fHasta.ToString("yyyy-MM-dd");
            ViewData["fHasta"] = dateHasta;
            ViewData["fHasta"] = fHasta.ToString("yyyy-MM-dd");
            ViewData["maxAlojamientos"] = 10;
            ViewData["cantAlojamientos"] = _context.Alojamiento.Count();
            ViewData["aEstrellas"] = aEstrellas;
            ViewData["aPrecioHasta"] = aPrecioHasta;
            ViewData["aPrecioDesde"] = aPrecioDesde;
            ViewData["rPrecioDesde"] = rPrecioDesde;
            ViewData["rPrecioHasta"] = rPrecioHasta;
            IDictionary<int, float> listaPrecio = new Dictionary<int, float>();
            ViewBag.ListaPrecio = listaPrecio;

            var a = await _context.Alojamiento.ToListAsync();
            if (fDesde.Date < DateTime.Now.Date && fDesde.Year != 1)
            {
                ViewBag.Message = string.Format("La fecha desde no puede ser anterior a la fecha actual.");
                ViewData["aCiudad"] = null;
                return View(a);
            }
            else if (fDesde.Date > fHasta.Date)
            {
                ViewBag.Message = string.Format("La fecha desde no puede ser mayor a la fecha hasta.");
                ViewData["aCiudad"] = null;
                return View(a);
            }

            if (fDesde.Year != 1 || fHasta.Year != 1)
            {
                var queryReservas = from r in _context.Reservas
                                    where (fDesde.Date >= r.fDesde && fHasta.Date <= r.fHasta) ||
                                            (fHasta.Date >= r.fDesde && fHasta.Date <= r.fHasta) ||
                                            (fDesde.Date >= r.fDesde && fDesde.Date <= r.fHasta) ||
                                            (fDesde.Date <= r.fDesde && fHasta.Date >= r.fHasta)
                                    orderby r.codAlojamiento
                                    select r;

                var queryAlojamientos = from aloj in _context.Alojamiento
                                        where (aTipo == "Ambos" || (aTipo == "Hotel" && aloj.Tipo == "Hotel") || (aTipo == "Cabaña" && aloj.Tipo == "Cabaña")) &&
                                                (aCiudad == "" || aloj.aCiudad.Contains(aCiudad)) &&
                                                (aCantPersonas == 0 || aloj.aCantPersonas >= aCantPersonas) &&
                                                (aEstrellas == 0 || aloj.aEstrellas == aEstrellas) &&
                                                (aPrecioDesde == 0 ||
                                                    (aTipo == "Hotel" && aloj.hPrecioxPersona >= aPrecioDesde) ||
                                                    (aTipo == "Cabaña" && aloj.cPrecioxDia >= aPrecioDesde) ||
                                                    (aTipo == "Ambos" && ((aloj.Tipo == "Hotel" && aloj.hPrecioxPersona >= aPrecioDesde) ||
                                                    (aloj.Tipo == "Cabaña" && aloj.cPrecioxDia >= aPrecioDesde)))) &&
                                                (aPrecioHasta == 0 ||
                                                    (aTipo == "Hotel" && aloj.hPrecioxPersona <= aPrecioHasta) ||
                                                    (aTipo == "Cabaña" && aloj.cPrecioxDia <= aPrecioHasta) ||
                                                    (aTipo == "Ambos" && ((aloj.Tipo == "Hotel" && aloj.hPrecioxPersona <= aPrecioHasta) ||
                                                    (aloj.Tipo == "Cabaña" && aloj.cPrecioxDia <= aPrecioHasta))))
                                        select aloj;

                List<Alojamiento> alojamientosUsuario = new List<Alojamiento>();
                List<Alojamiento> alojamientosFiltrados = queryAlojamientos.ToList();
                List<Reservas> reservasFiltradas = queryReservas.ToList();

                foreach (Alojamiento alojamiento in alojamientosFiltrados)
                {
                    bool agregarAlojamiento = true;
                    int cantOcupada = 0;
                    
                    cantOcupada += aCantPersonas;
                    if (cantOcupada > alojamiento.aCantPersonas)
                    {
                        agregarAlojamiento = false;
                    }
                    if (agregarAlojamiento)
                    {
                        if (rPrecioDesde > 0 || rPrecioHasta > 0)
                        {
                            float precioReserva = calcularPrecioReserva(alojamiento.aCodigo, fDesde, fHasta, aCantPersonas);
                            if ((rPrecioDesde == 0 || (rPrecioDesde > 0 && precioReserva >= rPrecioDesde)) &&
                               (rPrecioHasta == 0) || (rPrecioHasta > 0 && precioReserva <= rPrecioHasta))
                            {
                                alojamientosUsuario.Add(alojamiento);
                            }
                        }
                        else
                        {
                            alojamientosUsuario.Add(alojamiento);
                        }
                    }
                }

                if (alojamientosUsuario.Count() < 1)
                {
                    if (rPrecioDesde > rPrecioHasta)
                    {
                        ViewBag.Message = string.Format("El rango de precio de Reserva debe ser: menor en desde y mayor en hasta.");
                    }
                    else if (aPrecioDesde > aPrecioHasta)
                    {
                        ViewBag.Message = string.Format("El rango de precio Dia/Persona debe ser: menor en desde y mayor en hasta");
                    }
                    else
                    {
                        ViewBag.Message = string.Format("No hay alojamientos disponibles para reservar segun la busqueda realizada. Intente nuevamente.");
                        ViewData["aCiudad"] = null;
                    }
                }
                else
                {
                    foreach (Alojamiento alojExistente in alojamientosUsuario)
                    {
                        float precio = calcularPrecioReserva(alojExistente.aCodigo, fDesde, fHasta, aCantPersonas);
                        int id = alojExistente.aCodigo;
                        listaPrecio.Add(id, precio);
                    }
                    ViewBag.ListaPrecio = listaPrecio;
                }

                switch (sortOrder)
                {
                    case "preciodia":
                        alojamientosUsuario = alojamientosUsuario.ToList().OrderByDescending(a => a.cPrecioxDia).ToList();
                        break;
                    case "preciodiab":
                        alojamientosUsuario = alojamientosUsuario.ToList().OrderBy(a => a.cPrecioxDia).ToList();
                        break;
                    case "preciopersona":
                        alojamientosUsuario = alojamientosUsuario.ToList().OrderByDescending(a => a.hPrecioxPersona).ToList();
                        break;
                    case "preciopersonab":
                        alojamientosUsuario = alojamientosUsuario.ToList().OrderBy(a => a.hPrecioxPersona).ToList();
                        break;
                    case "estrellas":
                        alojamientosUsuario = alojamientosUsuario.ToList().OrderByDescending(a => a.aEstrellas).ToList();
                        break;
                    case "estrellasb":
                        alojamientosUsuario = alojamientosUsuario.ToList().OrderBy(a => a.aEstrellas).ToList();
                        break;
                    case "capacidad":
                        alojamientosUsuario = alojamientosUsuario.ToList().OrderByDescending(a => a.aCantPersonas).ToList();
                        break;
                    case "capacidadb":
                        alojamientosUsuario = alojamientosUsuario.ToList().OrderBy(a => a.aCantPersonas).ToList();
                        break;
                    case "precioreserva":
                        Alojamiento alojAux3 = new Alojamiento();
                        for (int j = 0; j <= alojamientosUsuario.Count - 2; j++)
                        {
                            for (int i = 0; i <= alojamientosUsuario.Count - 2; i++)
                            {
                                if (calcularPrecioReserva(alojamientosUsuario[i].aCodigo, fDesde, fHasta, aCantPersonas) < calcularPrecioReserva(alojamientosUsuario[i + 1].aCodigo, fDesde, fHasta, aCantPersonas))
                                {
                                    alojAux3 = alojamientosUsuario[i + 1];
                                    alojamientosUsuario[i + 1] = alojamientosUsuario[i];
                                    alojamientosUsuario[i] = alojAux3;
                                }
                            }
                        }
                        break;
                    case "precioreservab":
                        Alojamiento alojAux4 = new Alojamiento();
                        for (int j = 0; j <= alojamientosUsuario.Count - 2; j++)
                        {
                            for (int i = 0; i <= alojamientosUsuario.Count - 2; i++)
                            {
                                if (calcularPrecioReserva(alojamientosUsuario[i].aCodigo, fDesde, fHasta, aCantPersonas) > calcularPrecioReserva(alojamientosUsuario[i + 1].aCodigo, fDesde, fHasta, aCantPersonas))
                                {
                                    alojAux4 = alojamientosUsuario[i + 1];
                                    alojamientosUsuario[i + 1] = alojamientosUsuario[i];
                                    alojamientosUsuario[i] = alojAux4;
                                }
                            }
                        }
                        break;
                    default:
                        alojamientosUsuario = alojamientosUsuario.ToList().OrderBy(a => a.aEstrellas).ThenBy(a => a.aCantPersonas).ThenBy(a => a.aCodigo).ToList();
                        break;
                }
                return View(alojamientosUsuario);
            }
            else if (User.IsInRole("Admin"))
            {
                switch (sortOrder)
                {
                    case "preciodia":
                        a = a.ToList().OrderByDescending(a => a.cPrecioxDia).ToList();
                        break;
                    case "preciodiab":
                        a = a.ToList().OrderBy(a => a.cPrecioxDia).ToList();
                        break;
                    case "preciopersona":
                        a = a.ToList().OrderByDescending(a => a.hPrecioxPersona).ToList();
                        break;
                    case "preciopersonab":
                        a = a.ToList().OrderBy(a => a.hPrecioxPersona).ToList();
                        break;
                    case "estrellas":
                        a = a.ToList().OrderByDescending(a => a.aEstrellas).ToList();
                        break;
                    case "estrellasb":
                        a = a.ToList().OrderBy(a => a.aEstrellas).ToList();
                        break;
                    case "capacidad":
                        a = a.ToList().OrderByDescending(a => a.aCantPersonas).ToList();
                        break;
                    case "capacidadb":
                        a = a.ToList().OrderBy(a => a.aCantPersonas).ToList();
                        break;
                    default:
                        a = a.ToList().OrderBy(a => a.aEstrellas).ThenBy(a => a.aCantPersonas).ThenBy(a => a.aCodigo).ToList();
                        break;
                }
                return View(a);
            }
            return View(getAlojamientosOrdenados(a));
        }

        public List<Alojamiento> getAlojamientosOrdenados(List<Alojamiento> a)
        {
            return a.ToList().OrderBy(a => a.aEstrellas).ThenBy(a => a.aCantPersonas).ThenBy(a => a.aCodigo).ToList();
        }

        public float calcularPrecioReserva(int codAloj, DateTime fDesde, DateTime fHasta, int cantPersonas)
        {
            float precio = 0;
            var span = fHasta.Date.Subtract(fDesde.Date);
            int dias = span.Days;
            dias = dias + 1;
            Alojamiento propiedad = devolverAlojamiento(codAloj);

            if (propiedad != null && propiedad.Tipo == "Hotel")
            {
                precio = Convert.ToSingle(propiedad.hPrecioxPersona * cantPersonas * dias);
            }
            else if (propiedad != null)
            {
                precio = Convert.ToSingle(propiedad.cPrecioxDia * dias);
            }
            return precio;
        }
        public Alojamiento devolverAlojamiento(int codAloj)
        {
            var queryAlojamientos = from aloj in _context.Alojamiento
                                    select aloj;

            if (queryAlojamientos != null)
            {
                foreach (Alojamiento alojamiento in queryAlojamientos)
                {
                    if (alojamiento.aCodigo == codAloj)
                    {
                        return alojamiento;
                    }
                }
            }
            return null;
        }
    }
}

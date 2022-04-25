using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using plataformasGrupo5TPFinal.Models;
using plataformasGrupo5TPFinal.Data;
using plataformasGrupo5TPFinal.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace plataformasGrupo5TPFinal.Controllers
{
    [Authorize]
    public class MyController : Controller
    {
        public List<Alojamiento> alojamientos = new List<Alojamiento>();
        private readonly UserContext _context;

        public MyController(UserContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Abm()
        {
            return View();
        }

        public async Task<IActionResult> Buscador(string searchString, string searchCiudad , int tipoAloj)
        {
            alojamientos = GetAlojamientos();
             
            //filtro por searchString si es que me lo pasaron... ESTO ES SOLO POR nombre
            if (!String.IsNullOrEmpty(searchString))
            {
                alojamientos = alojamientos.FindAll(h => h.nombre.Contains(searchString));
            }
                             

            if (!String.IsNullOrEmpty(searchCiudad))
            {
                alojamientos = alojamientos.FindAll(h => h.ciudad.Contains(searchCiudad));
            }
                      
            return View(alojamientos);

        }

        public List<Hotel> GetHoteles()
        {
            List<Hotel> hotel = new List<Hotel>();
            foreach (Hotel h in _context.Hotel.ToList())
            {
                hotel.Add(h);
            }
            return hotel;
        }
        public List<Cabaña> GetCabanias()
        {
            List<Cabaña> cabania = new List<Cabaña>();
            foreach (Cabaña c in _context.Cabaña.ToList())
            {
                cabania.Add(c);
            }
            return cabania;
        }

        public async Task<IActionResult> BarraBuscador(string searchString)
        {
            
            var hotel = from h in _context.Hotel
                           select h;
            var cabania = from c in _context.Cabaña
                        select c;

            //filtro por searchString si es que me lo pasaron...
            if (!String.IsNullOrEmpty(searchString))
            {
                hotel = hotel.Where(h => h.nombre.Contains(searchString));
                cabania = cabania.Where(c => c.nombre.Contains(searchString));
            }

            if (searchString.Equals(hotel)) { 
            //devuelvo el contenido a la vista
            return View(await hotel.ToListAsync());
        } else
            {
                return View(await cabania.ToListAsync());
            }
    }
        public List<Alojamiento> GetAlojamientos()
        {
            List<Alojamiento> alojs = new List<Alojamiento>();
            foreach (Alojamiento hotel in _context.Hotel)
            {
                alojs.Add(hotel);
            }
            foreach (Alojamiento cabaña in _context.Cabaña)
            {
                alojs.Add(cabaña);
            }
            return alojs;
        }
    }

}

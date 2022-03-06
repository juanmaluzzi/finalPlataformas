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
using System.Dynamic;

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
            dynamic mymodel = new ExpandoObject();
            mymodel.Hotel = GetHoteles();
            mymodel.Cabaña = GetCabanias();
            
           if (tipoAloj == 3) {  

            var hotel = from h in _context.Hotel
                        select h;
            var cabania = from c in _context.Cabaña
                          select c;


            
            //filtro por searchString si es que me lo pasaron... ESTO ES SOLO POR nombre
            if (!String.IsNullOrEmpty(searchString))
            {
                mymodel.Hotel = hotel.Where(h => h.nombre.Contains(searchString) ||  h.codigo.Equals(searchString));
                mymodel.Cabaña = cabania.Where(c => c.nombre.Contains(searchString) || c.codigo.Equals(searchString));

             
            }

            

            if (!String.IsNullOrEmpty(searchCiudad))
            {
                mymodel.Hotel = hotel.Where(h => h.ciudad.Contains(searchCiudad));
                mymodel.Cabaña = cabania.Where(c => c.ciudad.Contains(searchCiudad));


            } 
        } else if (tipoAloj == 1)
            {
                var hotel = from h in _context.Hotel
                            select h;
               



                //filtro por searchString si es que me lo pasaron... ESTO ES SOLO POR nombre
                if (!String.IsNullOrEmpty(searchString))
                {
                    mymodel.Hotel = hotel.Where(h => h.nombre.Contains(searchString) || h.codigo.Equals(searchString));
                  


                }



                if (!String.IsNullOrEmpty(searchCiudad))
                {
                    mymodel.Hotel = hotel.Where(h => h.ciudad.Contains(searchCiudad));
                   


                }
            }
                return View(mymodel);

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

        
    }

    }


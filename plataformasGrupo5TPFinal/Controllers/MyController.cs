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

    }

}

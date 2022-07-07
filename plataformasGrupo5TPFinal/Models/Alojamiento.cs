using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using plataformasGrupo5TPFinal.Data;

namespace plataformasGrupo5TPFinal.Models
{
    public abstract class Alojamiento
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string ciudad { get; set; }
        public string barrio { get; set; }
        public int estrellas { get; set; }
        public int cantPersonas { get; set; }
        public bool tv { get; set; }

        private readonly UserContext _context;

        public override string ToString()
        {
            return "Cod: "+ codigo + "/ Nombre: " + nombre + " / Ciudad: " + ciudad + " / Barrio " + barrio + " / Estrellas: " + estrellas + " / Cant. Personas: " + cantPersonas +  " / Tv: " + tv;
        }
        public bool igualCodigo(Alojamiento a)
        {
            return codigo == a.codigo;
        }

        public int getCodigoAlojamiento() {
            return codigo;
        }

        public float getPrecio(Alojamiento aloj) {
            if(aloj is Hotel)
            {
                Hotel h = (Hotel)aloj;
                return h.precioPorPersona;
            }
            else
            {
                Cabaña c = (Cabaña)aloj;
                return c.precioDia;
            }
        }

        public List<Alojamiento> GetAlojamientos()
        {
            List<Alojamiento> alojs = new List<Alojamiento>();
            foreach(Alojamiento hotel in _context.Hotel)
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

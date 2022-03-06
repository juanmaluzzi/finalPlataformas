using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace plataformasGrupo5TPFinal.Models
{
    public class Cabaña : Alojamiento
    {
        [Key]
        public int idCabana { get; set; }
        public float precioDia { get; set; }
        public int habitaciones { get; set; }
        public int baños { get; set; }

        public Cabaña() { }
        public Cabaña(int Codigo, string Nombre, string Ciudad, string Barrio, int Estrellas, int CantPersonas, bool Tv, float PrecioDIA, int Habitaciones, int Baños)
        {
            codigo = Codigo; 
            nombre = Nombre;
            ciudad = Ciudad;
            barrio = Barrio;
            estrellas = Estrellas;
            cantPersonas = CantPersonas;
            tv = Tv;
            precioDia = PrecioDIA;
            habitaciones = Habitaciones;
            baños = Baños;
        }


        public override string ToString()
        {
            return base.ToString() + " Precio: " + precioDia;
        }

    }
}

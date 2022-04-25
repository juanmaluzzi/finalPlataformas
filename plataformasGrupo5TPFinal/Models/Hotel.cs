using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace plataformasGrupo5TPFinal.Models
{
    public class Hotel : Alojamiento
    {
        [Key]
        public int idHotel { get; set; }
        public float precioPorPersona { get; set; }

        public Hotel() { }
        public Hotel(int Codigo, string Nombre, string Ciudad, string Barrio, int Estrellas, int CantPersonas, bool Tv, float PrecioPP)
        {
            codigo = Codigo;
            nombre = Nombre;
            ciudad = Ciudad;
            barrio = Barrio;
            estrellas = Estrellas;
            cantPersonas = CantPersonas;
            tv = Tv;
            precioPorPersona = PrecioPP;
        }

        public override string ToString()
        {
            return base.ToString() + " Precio: " + precioPorPersona;
        }

    }
}

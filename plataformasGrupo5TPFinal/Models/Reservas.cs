using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace plataformasGrupo5TPFinal.Models
{
    public class Reservas
    {
        [Key]
        public int id { get; set; }
        public DateTime fDesde { get; set; }
        public DateTime fHasta { get; set; }

        public int codAlojamiento { get; set; }
        
        public int dniPersona { get; set; }
        public float precio { get; set; }

        public Reservas() { }
        public Reservas (int ID, DateTime FDesde, DateTime FHasta, Alojamiento Propiedad, Usuario Persona , float Precio)
        {
            id = ID;
            fDesde = FDesde;
            fHasta = FHasta;
            codAlojamiento = Propiedad.aCodigo;
            dniPersona = Persona.getDNIUser();
            precio = Precio;

        }
        public override string ToString()
        {
            return "ID: " + id + "/ Fecha Desde: " + fDesde + " / Fecha Hasta: " + fHasta + " / Alojamiento: " + codAlojamiento + " / Usuario: " + dniPersona + " / Precio: " + precio;
        }
    }

}


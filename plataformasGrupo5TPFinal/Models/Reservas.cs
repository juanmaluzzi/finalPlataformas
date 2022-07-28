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
        public Reservas (int ID, DateTime FDesde, DateTime FHasta, int CodAlojamiento, int DniUser , float Precio)
        {
            id = ID;
            fDesde = FDesde;
            fHasta = FHasta;
            codAlojamiento = CodAlojamiento;
            dniPersona = DniUser;
            precio = Precio;

        }
        public override string ToString()
        {
            return "ID: " + id + "/ Fecha Desde: " + fDesde + " / Fecha Hasta: " + fHasta + " / Alojamiento: " + codAlojamiento + " / Usuario: " + dniPersona + " / Precio: " + precio;
        }
    }

}


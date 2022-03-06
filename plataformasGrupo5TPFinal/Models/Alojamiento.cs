using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

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

    }
}

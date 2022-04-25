using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace plataformasGrupo5TPFinal.ViewModels
{
    public class GestorReservasViewModel
    {
        [Required(ErrorMessage = "Obligatorio")]
        [DataType(DataType.Text)]
        [Display(Name = "Alojamiento")]
        public string AlojamientoSeleccionado { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [DataType(DataType.Text)]
        [Display(Name = "DNIUsuario")]
        public string DniUsuario { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [DataType(DataType.Date)]
        [Display(Name = "FechaDesde")]
        public string FechaDesde { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [DataType(DataType.Date)]
        [Display(Name = "FechaHasta")]
        public string FechaHasta { get; set; }

    }
}

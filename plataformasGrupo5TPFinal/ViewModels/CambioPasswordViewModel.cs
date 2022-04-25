using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace plataformasGrupo5TPFinal.ViewModels
{
    public class CambioPasswordViewModel
    {
        [Required(ErrorMessage = "Obligatorio")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña actual")]
        public string PasswordActual { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [DataType(DataType.Password)]
        [Display(Name = "Nueva contraseña")]
        public string NuevaPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar nueva contraseña")]
        [Compare("NuevaPassword", ErrorMessage = "La contraseña nueva y la confirmación no coinciden")]

        public string ConfirmarPassword { get; set; }


    }
}

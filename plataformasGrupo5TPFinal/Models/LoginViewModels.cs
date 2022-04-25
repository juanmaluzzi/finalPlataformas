using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace plataformasGrupo5TPFinal.Models
{
    public class LoginViewModels
    {
        [BindProperty]
        public InputModel Input { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }
        public class InputModel 
        {
            [Required]
            public int Dni { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

        }
    }
}

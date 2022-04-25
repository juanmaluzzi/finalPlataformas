using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace plataformasGrupo5TPFinal.Models
{
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Documento")]
        public int dni { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "E-Mail")]
        public string mail { get; set; }
        [Display(Name = "Password")]
        public string password { get; set; }
        [Display(Name = "Admin")]
        public bool esAdmin { get; set; }
        [Display(Name = "Bloqueado")]
        public bool bloqueado { get; set; }
        public int intentos { get; set; }

        public Usuario() { }
        public Usuario( int Dni, string Nombre, string Mail, string Password, bool EsAdmin, bool Bloqueado, int Intentos)
        {
            dni = Dni;
            nombre = Nombre;
            mail = Mail;
            password = Password;
            esAdmin = EsAdmin;
            bloqueado = Bloqueado;
            intentos = Intentos;
        }

        public int getDNIUser() {
            return dni;
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Usuario
    {
        [Key]
        public string NumeroCedula { get; set; }
        public int TipoUsuario { get; set; }
        public string TipoUsuarioNombre { get; set; } 
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string NombreCompleto { get; set; }      
        public string UsuarioI { get; set; }
        public string Contrasena { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public void SetTipoUsuarioNombre(){
            string[] tipo = {};
            tipo[1] = "Administrador";
            tipo[2] = "Técnico";
            this.TipoUsuarioNombre = tipo[this.TipoUsuario];
        }

        public void SetNombreCompleto(){
            this.NombreCompleto = this.PrimerNombre +' '+ this.SegundoNombre +' '+ this.PrimerApellido +' '+ this.SegundoApellido;
        }
    }
}

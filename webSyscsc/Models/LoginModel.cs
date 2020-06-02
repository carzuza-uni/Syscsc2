using Entity;

namespace webSyscsc.Models
{
    public class LoginInputModel
    {
        public string UsuarioI { get; set; }
        public string Contrasena { get; set; }
        public string Token { get; set; }
    }

    public class LoginViewModel : LoginInputModel
    {
        public LoginViewModel()
        {

        }
        public LoginViewModel(Usuario usuario)
        {
            TipoUsuario = usuario.TipoUsuario;
            TipoUsuarioNombre = usuario.TipoUsuarioNombre;
            PrimerNombre = usuario.PrimerNombre;
            SegundoNombre = usuario.SegundoNombre;
            PrimerApellido = usuario.PrimerApellido;
            SegundoApellido = usuario.SegundoApellido;
            NombreCompleto = usuario.NombreCompleto;
            NumeroCedula = usuario.NumeroCedula;
            UsuarioI = usuario.UsuarioI;
            Telefono = usuario.Telefono;
            Email = usuario.Email;
        }
        public int TipoUsuario { get; set; }
        public string TipoUsuarioNombre { get; set; } 
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string NombreCompleto { get; set; }  
        public string NumeroCedula { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}
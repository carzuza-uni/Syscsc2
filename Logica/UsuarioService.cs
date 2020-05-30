using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;

namespace Logica
{
    public class UsuarioService
    {
        //private readonly ConnectionManager conexion;
        //private readonly UsuarioRepository repository;
        private readonly SyscscContext _context;

        public UsuarioService(SyscscContext context)
        {
            _context = context;
            //conexion = new ConnectionManager(connectionString);
            //repository = new UsuarioRepository(conexion);
        }

        public GuardarUsuarioResponse Guardar(Usuario usuario){
            try{
                var usurioBuscado = _context.Usuarios.Find(usuario.NumeroCedula);
                if(usurioBuscado != null){
                    return new GuardarUsuarioResponse("Error el usuario ya se encuentra registrado");
                }
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return new GuardarUsuarioResponse(usuario);
            }catch(Exception e){ 
                return new GuardarUsuarioResponse($"Error de la aplicacion: {e.Message}");
            }
        }

        public List<Usuario> ConsultarTodos(){            
            List<Usuario> usuarios= _context.Usuarios.ToList();
            return usuarios;
        }

        public Usuario BuscarUsuario(string numeroCedula){            
            Usuario usurioBuscado = _context.Usuarios.Find(numeroCedula);                
            return usurioBuscado;
        }
    }

    public class GuardarUsuarioResponse 
    {
        public GuardarUsuarioResponse(Usuario usuario1)
        {
            Error = false;
            usuario = usuario1;
        }
        public GuardarUsuarioResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Usuario usuario { get; set; }
    }
}

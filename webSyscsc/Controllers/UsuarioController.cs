using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using webSyscsc.Models;
using Entity;
using Logica;
using Datos;
using webSyscsc.Config;
using webSyscsc.Service;

namespace webSyscsc.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController: ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        //public IConfiguration Configuration { get; }

        public UsuarioController(SyscscContext context)
        {
            //Configuration = configuration;
            //string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _usuarioService = new UsuarioService(context);
        }

        [HttpPost]
        public ActionResult<UsuarioViewModel> post(UsuarioInputModel usuarioInput){
            Usuario usuario = MapearUsuario(usuarioInput);
            var response = _usuarioService.Guardar(usuario);
            if(response.Error){
                return BadRequest(response.Mensaje);
            }
            return Ok(response.usuario);
        }
        private Usuario MapearUsuario(UsuarioInputModel usuarioInput)
        {
            var usuario = new Usuario
            {
                TipoUsuario = usuarioInput.TipoUsuario,
                TipoUsuarioNombre = usuarioInput.TipoUsuarioNombre,
                PrimerNombre = usuarioInput.PrimerNombre,
                SegundoNombre = usuarioInput.SegundoNombre,
                PrimerApellido = usuarioInput.PrimerApellido,
                SegundoApellido = usuarioInput.SegundoApellido,
                NombreCompleto = usuarioInput.NombreCompleto,
                NumeroCedula = usuarioInput.NumeroCedula,
                UsuarioI = usuarioInput.UsuarioI,
                Contrasena = usuarioInput.Contrasena,
                Telefono = usuarioInput.Telefono,
                Email = usuarioInput.Email
            };
            return usuario;
        }

        [HttpGet]
        public IEnumerable<UsuarioViewModel> gets(){
            var usuarios = _usuarioService.ConsultarTodos().Select(p=> new UsuarioViewModel(p));
            return usuarios;
        }
    }
} 
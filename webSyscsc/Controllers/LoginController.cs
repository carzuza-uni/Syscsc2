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
using Datos;
using webSyscsc.Config;
using webSyscsc.Service;

namespace webSyscsc.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private JwtService _jwtService;
        private readonly UsuarioService _usuarioService;
        
        public LoginController(SyscscContext context, IOptions<AppSetting> appSettings)
        {
            /*
            _context = context;
            var admin = _context.Usuarios.Find("admin");
            if (admin == null)
            {
                _context.Usuarios.Add(new Entity.Usuario() { NombreUsuario = "admin", Contrasena="admin", Estado ="Activo", Nombre="Adminitrador", Apellido="Administrador", NumeroTelefono="31800000000", Email = "admin@gmail.com"});
                var i = _context.SaveChanges();
            }
            */
            _jwtService = new JwtService(appSettings);            
            _usuarioService = new UsuarioService(context);
        }

        [AllowAnonymous]
        [HttpPost()]
        public IActionResult Login(LoginInputModel login)
        {
            var user = _usuarioService.Validate(login.UsuarioI, login.Contrasena);

            if (user == null)
            {
                ModelState.AddModelError("Acceso Denegado", "Usuario y/o Contraseña es incorrecta");
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            var response = _jwtService.GenerarToken(user);

            return Ok(response);
        }
    }
}
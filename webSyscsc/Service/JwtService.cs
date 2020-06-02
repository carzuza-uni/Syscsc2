using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using webSyscsc.Models;
using webSyscsc.Config;
using Logica;
using Entity;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using System.Text;

namespace webSyscsc.Service
{
    public class JwtService
    {
        private readonly AppSetting _appSetting;
        public JwtService(IOptions<AppSetting> appSetting)
        {
            _appSetting = appSetting.Value;
        }

        public LoginViewModel GenerarToken(Usuario usuario)
        {
            if(usuario == null)
                return null;
            
            var usuarioResponse = new LoginViewModel(usuario)
            {
                TipoUsuario = usuario.TipoUsuario,
                TipoUsuarioNombre = usuario.TipoUsuarioNombre,
                PrimerNombre = usuario.PrimerNombre,
                SegundoNombre = usuario.SegundoNombre,
                PrimerApellido = usuario.PrimerApellido,
                SegundoApellido = usuario.SegundoApellido,
                NombreCompleto = usuario.NombreCompleto,
                NumeroCedula = usuario.NumeroCedula,
                UsuarioI = usuario.UsuarioI,
                Telefono = usuario.Telefono,
                Email = usuario.Email
            };
            
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSetting.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, usuario.NombreCompleto),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.MobilePhone, usuario.Telefono),
                    new Claim(ClaimTypes.Role, "Rol1"),
                    new Claim(ClaimTypes.Role, "Rol2"),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            usuarioResponse.Token = tokenHandler.WriteToken(token);

            return usuarioResponse;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using webSyscsc.Models;
using Entity;
using Logica;
using Datos;

namespace webSyscsc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsumoExternoController: ControllerBase
    {
        private readonly InsumoExternoService _insumoExternoService;

        public InsumoExternoController(SyscscContext context)
        {
            _insumoExternoService = new InsumoExternoService(context);
        }

        [HttpPost]
        public ActionResult<InsumoExternoViewModel> post(InsumoExternoInputModel insumoExternoInput){
            InsumoExterno insumoExterno = Mapear(insumoExternoInput);
            var response = _insumoExternoService.Guardar(insumoExterno);
            if(response.Error){
                return BadRequest(response.Mensaje);
            }
            return Ok(response.objeto);
        }

        private InsumoExterno Mapear(InsumoExternoInputModel insumoExternoInput){
            var insumoExterno = new InsumoExterno
            {
                InsumoExternoId = insumoExternoInput.InsumoExternoId,
                ProductorId = insumoExternoInput.ProductorId,
                Nombre = insumoExternoInput.Nombre,
                Fabricante = insumoExternoInput.Fabricante,
                RegistroICA = insumoExternoInput.RegistroICA,
                Composicion = insumoExternoInput.Composicion,
                Dosis = insumoExternoInput.Dosis,
                Cantidad = insumoExternoInput.Cantidad,
                FechaAplicacion = insumoExternoInput.FechaAplicacion,
                LugarAplicacion = insumoExternoInput.LugarAplicacion
            };
            return insumoExterno;
        }

        // PUT: api/InsumoExterno/5
        [HttpPut("{id}")]
        public ActionResult<InsumoExternoViewModel> put(InsumoExternoInputModel insumoExternoInput)
        {
            InsumoExterno insumoExterno = Mapear(insumoExternoInput);
            var response = _insumoExternoService.Modificar(insumoExterno.InsumoExternoId, insumoExterno);
            if(response.Error){
                return BadRequest(response.Mensaje);
            }
            return Ok(response.objeto);
        }

        // GET: api/InsumoExterno/5
        [HttpGet("{id}")]
        public IEnumerable<InsumoExternoViewModel> gets(int id){
            var insumoExternos = _insumoExternoService.ConsultarTodos(id).Select(c=> new InsumoExternoViewModel(c));
            return insumoExternos;
        }
    }
}
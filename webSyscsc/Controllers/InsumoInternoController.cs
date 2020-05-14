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
    public class InsumoInternoController: ControllerBase
    {
        private readonly InsumoInternoService _insumoInternoService;

        public InsumoInternoController(SyscscContext context)
        {
            _insumoInternoService = new InsumoInternoService(context);
        }

        [HttpPost]
        public ActionResult<InsumoInternoViewModel> post(InsumoInternoInputModel insumoInternoInput){
            InsumoInterno insumoInterno = Mapear(insumoInternoInput);
            var response = _insumoInternoService.Guardar(insumoInterno);
            if(response.Error){
                return BadRequest(response.Mensaje);
            }
            return Ok(response.objeto);
        }

        private InsumoInterno Mapear(InsumoInternoInputModel insumoInternoInput){
            var insumoInterno = new InsumoInterno
            {
                InsumoInternoId = insumoInternoInput.InsumoInternoId,
                ProveedorId = insumoInternoInput.ProveedorId,
                Nombre = insumoInternoInput.Nombre,
                MaterialesUsado = insumoInternoInput.MaterialesUsado,
                Procedimiento = insumoInternoInput.Procedimiento,
                TiempoPreparacion = insumoInternoInput.TiempoPreparacion,
                MetodoPreparacion = insumoInternoInput.MetodoPreparacion,
                Dosis = insumoInternoInput.Dosis,
                Cantidad = insumoInternoInput.Cantidad,
                FechaAplicacion = insumoInternoInput.FechaAplicacion,
                LugarAplicacion = insumoInternoInput.LugarAplicacion
            };
            return insumoInterno;
        }

        // PUT: api/InsumoInterno/5
        [HttpPut("{id}")]
        public ActionResult<InsumoInternoViewModel> put(InsumoInternoInputModel insumoInternoInput)
        {
            InsumoInterno insumoInterno = Mapear(insumoInternoInput);
            var response = _insumoInternoService.Modificar(insumoInterno.InsumoInternoId, insumoInterno);
            if(response.Error){
                return BadRequest(response.Mensaje);
            }
            return Ok(response.objeto);
        }

        // GET: api/InsumoInterno/5
        [HttpGet("{id}")]
        public IEnumerable<InsumoInternoViewModel> gets(int id){
            var insumoInternos = _insumoInternoService.ConsultarTodos(id).Select(c=> new InsumoInternoViewModel(c));
            return insumoInternos;
        }
    }
}
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
    public class ManejoCultivoController: ControllerBase
    {
        private readonly ManejoCultivoService _manejoCultivoService;

        public ManejoCultivoController(SyscscContext context)
        {
            _manejoCultivoService = new ManejoCultivoService(context);
        }

        [HttpPost]
        public ActionResult<ManejoCultivoViewModel> post(ManejoCultivoInputModel manejoCultivoInput){
            ManejoCultivo manejoCultivo = Mapear(manejoCultivoInput);
            var response = _manejoCultivoService.Guardar(manejoCultivo);
            if(response.Error){
                return BadRequest(response.Mensaje);
            }
            return Ok(response.objeto);
        }

        private ManejoCultivo Mapear(ManejoCultivoInputModel manejoCultivoInput){
            var manejoCultivo = new ManejoCultivo
            {
                ManejoCultivoId = manejoCultivoInput.ManejoCultivoId,
                AgroclimaticaId = manejoCultivoInput.AgroclimaticaId,
                Lote = manejoCultivoInput.Lote,
                Variedad = manejoCultivoInput.Variedad,
                NumeroArboles = manejoCultivoInput.NumeroArboles,
                SistemaRenovacion = manejoCultivoInput.SistemaRenovacion,
                FechaSiembra = manejoCultivoInput.FechaSiembra,
                DistanciaSiembra = manejoCultivoInput.DistanciaSiembra,
            };
            return manejoCultivo;
        }

        // PUT: api/ManejoCultivo/5
        [HttpPut("{id}")]
        public ActionResult<ManejoCultivoViewModel> put(ManejoCultivoInputModel manejoCultivoInput)
        {
            ManejoCultivo manejoCultivo = Mapear(manejoCultivoInput);
            var response = _manejoCultivoService.Modificar(manejoCultivo.ManejoCultivoId, manejoCultivo);
            if(response.Error){
                return BadRequest(response.Mensaje);
            }
            return Ok(response.objeto);
        }

        // GET: api/ManejoCultivo/5
        [HttpGet("{id}")]
        public IEnumerable<ManejoCultivoViewModel> gets(int id){
            var datosFamilias = _manejoCultivoService.ConsultarTodos(id).Select(c=> new ManejoCultivoViewModel(c));
            return datosFamilias;
        }
    }
}
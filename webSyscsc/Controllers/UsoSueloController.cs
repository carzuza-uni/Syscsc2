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
    public class UsoSueloController: ControllerBase
    {
        private readonly UsoSueloService _usoSueloService;

        public UsoSueloController(SyscscContext context)
        {
            _usoSueloService = new UsoSueloService(context);
        }

        [HttpPost]
        public ActionResult<UsoSueloViewModel> post(UsoSueloInputModel usoSueloInput){
            UsoSuelo usoSuelo = Mapear(usoSueloInput);
            var response = _usoSueloService.Guardar(usoSuelo);
            if(response.Error){
                return BadRequest(response.Mensaje);
            }
            return Ok(response.objeto);
        }

        private UsoSuelo Mapear(UsoSueloInputModel usoSueloInput){
            var usoSuelo = new UsoSuelo
            {
                UsoSueloId = usoSueloInput.UsoSueloId,
                AgroclimaticaId = usoSueloInput.AgroclimaticaId,
                Lote = usoSueloInput.Lote,
                Area = usoSueloInput.Area,
                Usos = usoSueloInput.Usos,
                Sombrio = usoSueloInput.Sombrio,
                PlanteadoProximoAno = usoSueloInput.PlanteadoProximoAno,
                Pendiente = usoSueloInput.Pendiente,
                PresentaErosion = usoSueloInput.PresentaErosion
            };
            return usoSuelo;
        }

        // PUT: api/UsoSuelo/5
        [HttpPut("{id}")]
        public ActionResult<UsoSueloViewModel> put(UsoSueloInputModel usoSueloInput)
        {
            UsoSuelo usoSuelo = Mapear(usoSueloInput);
            var response = _usoSueloService.Modificar(usoSueloInput.UsoSueloId, usoSuelo);
            if(response.Error){
                return BadRequest(response.Mensaje);
            }
            return Ok(response.objeto);
        }

        // GET: api/UsoSuelo/5
        [HttpGet("{id}")]
        public IEnumerable<UsoSueloViewModel> gets(int id){
            var datos = _usoSueloService.ConsultarTodos(id).Select(c=> new UsoSueloViewModel(c));
            return datos;
        }
    }
}
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
    public class AgroclimaticaController: ControllerBase
    {
        private readonly AgroclimaticaService _agroclimaticaService;

        public AgroclimaticaController(SyscscContext context)
        {
            _agroclimaticaService = new AgroclimaticaService(context);
        }

        [HttpPost]
        public ActionResult<AgroclimaticaViewModel> post(AgroclimaticaInputModel agroclimaticaInput){
            Agroclimatica agroclimatica = Mapear(agroclimaticaInput);
            var response = _agroclimaticaService.Guardar(agroclimatica);
            if(response.Error){
                return BadRequest(response.Mensaje);
            }
            return Ok(response.objeto);
        }

        private Agroclimatica Mapear(AgroclimaticaInputModel agroclimaticaInput){
            var agroclimatica = new Agroclimatica
            {
                AgroclimaticaId = agroclimaticaInput.AgroclimaticaId,
                ProductorId = agroclimaticaInput.ProductorId,
                Latitud = agroclimaticaInput.Latitud,
                NorteLongitud = agroclimaticaInput.NorteLongitud,
                Este = agroclimaticaInput.Este,
                MSNM = agroclimaticaInput.MSNM,
                AnalisisSuelo = agroclimaticaInput.AnalisisSuelo,
                FechaRealizacion = agroclimaticaInput.FechaRealizacion,
                PlanFertilizacion = agroclimaticaInput.PlanFertilizacion,
                TipoTextura = agroclimaticaInput.TipoTextura,
                PreparacionAbono = agroclimaticaInput.PreparacionAbono,
                Tipo = agroclimaticaInput.Tipo,
                Estado = agroclimaticaInput.Estado,
                Observaciones = agroclimaticaInput.Observaciones
            };
            return agroclimatica;
        }

        // PUT: api/Agroclimatica/5
        [HttpPut("{id}")]
        public ActionResult<AgroclimaticaViewModel> put(AgroclimaticaInputModel agroclimaticaInput)
        {
            Agroclimatica agroclimatica = Mapear(agroclimaticaInput);
            var response = _agroclimaticaService.Modificar(agroclimatica.AgroclimaticaId, agroclimatica);
            if(response.Error){
                return BadRequest(response.Mensaje);
            }
            return Ok(response.objeto);
        }

        // GET: api/Agroclimatica/5
        [HttpGet("{id}")]
        public ActionResult<AgroclimaticaViewModel> get(int id){
            var agroclimatica = _agroclimaticaService.Obtener(id);
            if(agroclimatica == null){
                return null;
            }
            AgroclimaticaViewModel c = new AgroclimaticaViewModel(agroclimatica);
            return c;
        }
    }
}
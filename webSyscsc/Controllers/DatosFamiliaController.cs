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
    public class DatosFamiliaController: ControllerBase
    {
        private readonly DatosFamiliaService _datosFamiliaService;

        public DatosFamiliaController(SyscscContext context)
        {
            _datosFamiliaService = new DatosFamiliaService(context);
        }

        [HttpPost]
        public ActionResult<DatosFamiliaViewModel> post(DatosFamiliaInputModel datosFamiliaInput){
            DatosFamilia datosFamilia = Mapear(datosFamiliaInput);
            var response = _datosFamiliaService.Guardar(datosFamilia);
            if(response.Error){
                return BadRequest(response.Mensaje);
            }
            return Ok(response.objeto);
        }

        private DatosFamilia Mapear(DatosFamiliaInputModel datosFamiliaInput){
            var datosFamilia = new DatosFamilia
            {
                Identificacion = datosFamiliaInput.Identificacion,
                ProductorId = datosFamiliaInput.ProductorId,
                Nombre = datosFamiliaInput.Nombre,
                FechaNacimiento = datosFamiliaInput.FechaNacimiento,
                Parentesco = datosFamiliaInput.Parentesco,
                TipoPoblacion = datosFamiliaInput.TipoPoblacion,
                AfilicionSalud = datosFamiliaInput.AfilicionSalud,
                NivelEducativo = datosFamiliaInput.NivelEducativo
            };
            return datosFamilia;
        }

        // PUT: api/DatosFamilia/5
        [HttpPut("{id}")]
        public ActionResult<DatosFamiliaViewModel> put(DatosFamiliaInputModel datosFamiliaInput)
        {
            DatosFamilia datosFamilia = Mapear(datosFamiliaInput);
            var response = _datosFamiliaService.Modificar(datosFamilia.Identificacion, datosFamilia);
            if(response.Error){
                return BadRequest(response.Mensaje);
            }
            return Ok(response.objeto);
        }

        // GET: api/DatosFamilia/5
        [HttpGet("{id}")]
        public IEnumerable<DatosFamiliaViewModel> gets(int id){
            var datosFamilias = _datosFamiliaService.ConsultarTodos(id).Select(c=> new DatosFamiliaViewModel(c));
            return datosFamilias;
        }
    }
}
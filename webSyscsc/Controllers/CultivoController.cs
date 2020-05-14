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
    public class CultivoController: ControllerBase
    {
        private readonly CultivoService _cultivoService;

        public CultivoController(SyscscContext context)
        {
            _cultivoService = new CultivoService(context);
        }

        [HttpPost]
        public ActionResult<CultivoViewModel> post(CultivoInputModel cultivoInput){
            Cultivo cultivo = Mapear(cultivoInput);
            var response = _cultivoService.Guardar(cultivo);
            if(response.Error){
                return BadRequest(response.Mensaje);
            }
            return Ok(response.cultivo);
        }

        private Cultivo Mapear(CultivoInputModel cultivoInput){
            var cultivo = new Cultivo
            {
                CultivoId = cultivoInput.CultivoId,
                Nombre = cultivoInput.Nombre
            };
            return cultivo;
        }

        // PUT: api/Cultivo/5
        [HttpPut("{id}")]
        public ActionResult<CultivoViewModel> put(CultivoInputModel cultivoInput)
        {
            Cultivo cultivo = Mapear(cultivoInput);
            var response = _cultivoService.Modificar(cultivo.CultivoId, cultivo);
            if(response.Error){
                return BadRequest(response.Mensaje);
            }
            return Ok(response.cultivo);
        }

        [HttpGet]
        public IEnumerable<CultivoViewModel> gets(){
            var cultivos = _cultivoService.ConsultarTodos().Select(c=> new CultivoViewModel(c));
            return cultivos;
        }
    }
}
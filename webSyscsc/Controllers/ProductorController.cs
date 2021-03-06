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
    public class ProductorController: ControllerBase
    {
        private readonly ProductorService _productorService;

        public ProductorController(SyscscContext context)
        {
            _productorService = new ProductorService(context);
        }

        [HttpPost]
        public ActionResult<ProductorViewModel> post(ProductorInputModel productorInput){
            Productor productor = Mapear(productorInput);
            var response = _productorService.Guardar(productor);
            if(response.Error){
                return BadRequest(response.Mensaje);
            }
            return Ok(response.productor);
        }

        private Productor Mapear(ProductorInputModel productorInput){
            var productor = new Productor
            {
                ProductorId = productorInput.ProductorId,
                MunicipioId = productorInput.MunicipioId,
                //Municipio = productorInput.Municipio,
                Nombre = productorInput.Nombre,
                Cedula = productorInput.Cedula,
                CedulaCafetera = productorInput.CedulaCafetera,
                NombrePredio = productorInput.NombrePredio,
                CodigoFinca = productorInput.CodigoFinca,
                CodigoSICA = productorInput.CodigoSICA,
                Actividades = productorInput.Actividades,
                Telefono = productorInput.Telefono,
                AfiliacionSalud = productorInput.AfiliacionSalud
            };
            return productor;
        }

        [HttpGet]
        public IEnumerable<ProductorViewModel> gets(){
            var productores = _productorService.ConsultarTodos().Select(c=> new ProductorViewModel(c));
            return productores;
        }

        // GET: api/Productor/5
        [HttpGet("{id}")]
        public ActionResult<ProductorViewModel> detalle(int id){
            Productor productor = _productorService.Detalle(id);
            if(productor == null){
                return null;
            }
            ProductorViewModel p = new ProductorViewModel(productor);
            return p;
        }
    }
}
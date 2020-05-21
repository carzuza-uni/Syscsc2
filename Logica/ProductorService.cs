using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;

namespace Logica
{
    public class ProductorService
    {
        private readonly SyscscContext _context;

        public ProductorService(SyscscContext context)
        {
            _context = context;
        }

        public GuardarProductorResponse Guardar(Productor productor){
            try{
                //var ProductorBuscado = _context.Productores.Find(productor.Cedula);
                //if(ProductorBuscado != null){
                    //return new GuardarProductorResponse("Error el Productor ya se encuentra registrado");
                //}
                var m = _context.Municipios.Find(productor.MunicipioId);
                productor.Municipio = m;
                _context.Productores.Add(productor);
                _context.SaveChanges();
                return new GuardarProductorResponse(productor);
            }catch(Exception e){ 
                return new GuardarProductorResponse($"Error de la aplicacion: {e.Message}");
            }
        }

        public List<Productor> ConsultarTodos(){  
            List<Productor> productor = _context.Productores.ToList();
            return productor;
        }

        public Productor Detalle(int productorId){  
            Productor productor = _context.Productores.Find(productorId);
            return productor;
        }
    }

    public class GuardarProductorResponse 
    {
        public GuardarProductorResponse(Productor productor1)
        {
            Error = false;
            productor = productor1;
        }
        public GuardarProductorResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Productor productor { get; set; }
    }
}
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

        public GuardarProveedorResponse Guardar(Proveedor proveedor){
            try{
                //var proveedorBuscado = _context.Proveedores.Find(proveedor.Cedula);
                //if(proveedorBuscado != null){
                    //return new GuardarProveedorResponse("Error el proveedor ya se encuentra registrado");
                //}
                var m = _context.Municipios.Find(proveedor.MunicipioId);
                proveedor.Municipio = m;
                _context.Proveedores.Add(proveedor);
                _context.SaveChanges();
                return new GuardarProveedorResponse(proveedor);
            }catch(Exception e){ 
                return new GuardarProveedorResponse($"Error de la aplicacion: {e.Message}");
            }
        }

        public List<Proveedor> ConsultarTodos(){  
            List<Proveedor> proveedor = _context.Proveedores.ToList();
            return proveedor;
        }
    }

    public class GuardarProveedorResponse 
    {
        public GuardarProveedorResponse(Proveedor proveedor1)
        {
            Error = false;
            proveedor = proveedor1;
        }
        public GuardarProveedorResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Proveedor proveedor { get; set; }
    }
}
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;

namespace Logica
{
    public class InsumoExternoService
    {
        private readonly SyscscContext _context;

        public InsumoExternoService(SyscscContext context)
        {
            _context = context;
        }
        
        public GuardarInsumoExternoResponse Guardar(InsumoExterno insumoExterno){
            try{
                /*var insumoExternoB = _context.InsumoExternos.Single(ie => ie.Nombre.toLowerCase().indexOf(insumoExterno.Nombre.toLowerCase()) !== -1);
                if(insumoExternoB != null){
                    return new GuardarInsumoExternoResponse("Error el insumo Externo ya se encuentra registrado");
                }*/
                var p = _context.Proveedores.Find(insumoExterno.ProveedorId);                
                p.InsumoExternos.Add(insumoExterno);
                _context.SaveChanges();
                return new GuardarInsumoExternoResponse(insumoExterno);
            }catch(Exception e){ 
                return new GuardarInsumoExternoResponse($"Error de la aplicacion: {e.Message}");
            }
        }

        public GuardarInsumoExternoResponse Modificar(int id, InsumoExterno insumoExterno){
            try{
                var insumoExternoB = _context.InsumoExternos.Find(id);
                if(insumoExternoB == null){
                    return new GuardarInsumoExternoResponse("Error el insumo Externo no se encuentra registrado");
                }

                //var p = _context.Proveedores.Find(datosFamilia.ProveedorId);  
                insumoExternoB.Nombre = insumoExterno.Nombre;
                insumoExternoB.Fabricante = insumoExterno.Fabricante;
                insumoExternoB.RegistroICA = insumoExterno.RegistroICA;
                insumoExternoB.Composicion = insumoExterno.Composicion;
                insumoExternoB.Dosis = insumoExterno.Dosis;
                insumoExternoB.Cantidad = insumoExterno.Cantidad;
                insumoExternoB.FechaAplicacion = insumoExterno.FechaAplicacion;
                insumoExternoB.LugarAplicacion = insumoExterno.LugarAplicacion;

                _context.InsumoExternos.Update(insumoExternoB);                
                _context.SaveChanges();
                return new GuardarInsumoExternoResponse(insumoExterno);
            }catch(Exception e){ 
                return new GuardarInsumoExternoResponse($"Error de la aplicacion: {e.Message}");
            }
        }
        
        public List<InsumoExterno> ConsultarTodos(int id){  
            List<InsumoExterno> insumoExternos = _context.InsumoExternos.Where(d => d.ProveedorId == id).ToList();
            return insumoExternos;
        }
    }

    public class GuardarInsumoExternoResponse 
    {
        public GuardarInsumoExternoResponse(InsumoExterno objeto1)
        {
            Error = false;
            objeto = objeto1;
        }
        public GuardarInsumoExternoResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public InsumoExterno objeto { get; set; }
    }
}
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;

namespace Logica
{
    public class InsumoInternoService
    {
        private readonly SyscscContext _context;

        public InsumoInternoService(SyscscContext context)
        {
            _context = context;
        }

        public GuardarInsumoInternoResponse Guardar(InsumoInterno insumoInterno){
            try{
                /*var insumoInternoB = _context.InsumoInternos.Single(ie => ie.Nombre.toLowerCase().indexOf(insumoInterno.Nombre.toLowerCase()) !== -1);
                if(insumoInternoB != null){
                    return new GuardarInsumoInternoResponse("Error el insumo Externo ya se encuentra registrado");
                }*/
                var p = _context.Productores.Find(insumoInterno.ProductorId);                
                p.InsumoInternos.Add(insumoInterno);
                _context.SaveChanges();
                return new GuardarInsumoInternoResponse(insumoInterno);
            }catch(Exception e){ 
                return new GuardarInsumoInternoResponse($"Error de la aplicacion: {e.Message}");
            }
        }

        public GuardarInsumoInternoResponse Modificar(int id, InsumoInterno insumoInterno){
            try{
                var insumoInternoB = _context.InsumoInternos.Find(id);
                if(insumoInternoB == null){
                    return new GuardarInsumoInternoResponse("Error el insumo Externo no se encuentra registrado");
                }

                //var p = _context.Productores.Find(datosFamilia.ProductorId);  
                insumoInternoB.Nombre = insumoInterno.Nombre;
                insumoInternoB.MaterialesUsado = insumoInterno.MaterialesUsado;
                insumoInternoB.Procedimiento = insumoInterno.Procedimiento;
                insumoInternoB.TiempoPreparacion = insumoInterno.TiempoPreparacion;
                insumoInternoB.MetodoPreparacion = insumoInterno.MetodoPreparacion;
                insumoInternoB.Dosis = insumoInterno.Dosis;
                insumoInternoB.Cantidad = insumoInterno.Cantidad;
                insumoInternoB.FechaAplicacion = insumoInterno.FechaAplicacion;
                insumoInternoB.LugarAplicacion = insumoInterno.LugarAplicacion;

                _context.InsumoInternos.Update(insumoInternoB);                
                _context.SaveChanges();
                return new GuardarInsumoInternoResponse(insumoInterno);
            }catch(Exception e){ 
                return new GuardarInsumoInternoResponse($"Error de la aplicacion: {e.Message}");
            }
        }
        
        public List<InsumoInterno> ConsultarTodos(int id){  
            List<InsumoInterno> insumoInternos = _context.InsumoInternos.Where(d => d.ProductorId == id).ToList();
            return insumoInternos;
        }
    }

    public class GuardarInsumoInternoResponse 
    {
        public GuardarInsumoInternoResponse(InsumoInterno objeto1)
        {
            Error = false;
            objeto = objeto1;
        }
        public GuardarInsumoInternoResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public InsumoInterno objeto { get; set; }
    }
}
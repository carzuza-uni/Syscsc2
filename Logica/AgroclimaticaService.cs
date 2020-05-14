using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;

namespace Logica
{
    public class AgroclimaticaService
    {
        private readonly SyscscContext _context;

        public AgroclimaticaService(SyscscContext context)
        {
            _context = context;
        }

        public GuardarAgroclimaticaResponse Guardar(Agroclimatica agroclimatica){
            try{
                /*var agroclimaticaB = _context.Agroclimaticas.Find(agroclimatica.Identificacion);
                if(agroclimaticaB != null){
                    return new GuardarAgroclimaticaResponse("Error el agroclimatica ya se encuentra registrado");
                }*/
                var p = _context.Proveedores.Find(agroclimatica.ProveedorId);                
                p.Agroclimatica = agroclimatica;
                _context.SaveChanges();
                return new GuardarAgroclimaticaResponse(agroclimatica);
            }catch(Exception e){ 
                return new GuardarAgroclimaticaResponse($"Error de la aplicacion: {e.Message}");
            }
        }

        public GuardarAgroclimaticaResponse Modificar(int id, Agroclimatica agroclimatica){
            try{
                var agroclimaticaB = _context.Agroclimaticas.Find(id);
                if(agroclimaticaB == null){
                    return new GuardarAgroclimaticaResponse("Error el agroclimatica no se encuentra registrado");
                }

                //var p = _context.Proveedores.Find(datosFamilia.ProveedorId);  
                agroclimaticaB.Latitud = agroclimatica.Latitud;
                agroclimaticaB.NorteLongitud = agroclimatica.NorteLongitud;
                agroclimaticaB.Este = agroclimatica.Este;
                agroclimaticaB.MSNM = agroclimatica.MSNM;
                agroclimaticaB.AnalisisSuelo = agroclimatica.AnalisisSuelo;
                agroclimaticaB.FechaRealizacion = agroclimatica.FechaRealizacion;
                agroclimaticaB.PlanFertilizacion = agroclimatica.PlanFertilizacion;
                agroclimaticaB.TipoTextura = agroclimatica.TipoTextura;
                agroclimaticaB.PreparacionAbono = agroclimatica.PreparacionAbono;
                agroclimaticaB.Tipo = agroclimatica.Tipo;
                agroclimaticaB.Estado = agroclimatica.Estado;
                agroclimaticaB.Observaciones = agroclimatica.Observaciones;

                _context.Agroclimaticas.Update(agroclimaticaB);                
                _context.SaveChanges();
                return new GuardarAgroclimaticaResponse(agroclimatica);
            }catch(Exception e){ 
                return new GuardarAgroclimaticaResponse($"Error de la aplicacion: {e.Message}");
            }
        }

        public Agroclimatica Obtener(int id){  
            var agroclimatica = _context.Agroclimaticas.Single(a => a.ProveedorId == id);
            return agroclimatica;
        }
    }

    public class GuardarAgroclimaticaResponse 
    {
        public GuardarAgroclimaticaResponse(Agroclimatica objeto1)
        {
            Error = false;
            objeto = objeto1;
        }
        public GuardarAgroclimaticaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Agroclimatica objeto { get; set; }
    }
}
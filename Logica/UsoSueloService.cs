using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;

namespace Logica
{
    public class UsoSueloService
    {
        private readonly SyscscContext _context;

        public UsoSueloService(SyscscContext context)
        {
            _context = context;
        }

        public GuardarUsoSueloResponse Guardar(UsoSuelo usoSuelo){
            try{
                var usoSueloB = _context.UsoSuelos.Find(usoSuelo.UsoSueloId);
                if(usoSueloB != null){
                    return new GuardarUsoSueloResponse("Error el datos Familia ya se encuentra registrado");
                }
                var p = _context.Agroclimaticas.Find(usoSuelo.AgroclimaticaId);  
                if(p == null){
                    return new GuardarUsoSueloResponse("Error los datos de agroclimatica no se encuentra registrada");
                }
                _context.UsoSuelos.Add(usoSuelo);
                _context.SaveChanges();
                return new GuardarUsoSueloResponse(usoSuelo);
            }catch(Exception e){ 
                return new GuardarUsoSueloResponse($"Error de la aplicacion: {e.Message}");
            }
        }

        public GuardarUsoSueloResponse Modificar(int id, UsoSuelo usoSuelo){
            try{
                var usoSueloB = _context.UsoSuelos.Find(id);
                if(usoSueloB == null){
                    return new GuardarUsoSueloResponse("Error el uso suelo no se encuentra registrado");
                }

                usoSueloB.Lote = usoSuelo.Lote;
                usoSueloB.Area = usoSuelo.Area;
                usoSueloB.Usos = usoSuelo.Usos;
                usoSueloB.Sombrio = usoSuelo.Sombrio;
                usoSueloB.PlanteadoProximoAno = usoSuelo.PlanteadoProximoAno;
                usoSueloB.Pendiente = usoSuelo.Pendiente;
                usoSueloB.PresentaErosion = usoSuelo.PresentaErosion;

                _context.UsoSuelos.Update(usoSueloB);                
                _context.SaveChanges();
                return new GuardarUsoSueloResponse(usoSuelo);
            }catch(Exception e){ 
                return new GuardarUsoSueloResponse($"Error de la aplicacion: {e.Message}");
            }
        }

        public List<UsoSuelo> ConsultarTodos(int id){  
            List<UsoSuelo> datos = _context.UsoSuelos.Where(d => d.AgroclimaticaId == id).ToList();
            return datos;
        }
    }

    public class GuardarUsoSueloResponse 
    {
        public GuardarUsoSueloResponse(UsoSuelo objeto1)
        {
            Error = false;
            objeto = objeto1;
        }
        public GuardarUsoSueloResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public UsoSuelo objeto { get; set; }
    }
}
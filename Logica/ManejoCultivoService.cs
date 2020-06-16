
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;

namespace Logica
{
    public class ManejoCultivoService
    {
        private readonly SyscscContext _context;

        public ManejoCultivoService(SyscscContext context)
        {
            _context = context;
        }

        public GuardarManejoCultivoResponse Guardar(ManejoCultivo manejoCultivo){
            try{
                var manejoCultivoB = _context.ManejoCultivos.Find(manejoCultivo.ManejoCultivoId);
                if(manejoCultivoB != null){
                    return new GuardarManejoCultivoResponse("Error el datos Familia ya se encuentra registrado");
                }
                var p = _context.Agroclimaticas.Find(manejoCultivo.AgroclimaticaId);  
                if(p == null){
                    return new GuardarManejoCultivoResponse("Error los datos de agroclimatica no se encuentra registrados");
                }
                _context.ManejoCultivos.Add(manejoCultivo);
                _context.SaveChanges();
                return new GuardarManejoCultivoResponse(manejoCultivo);
            }catch(Exception e){ 
                return new GuardarManejoCultivoResponse($"Error de la aplicacion: {e.Message}");
            }
        }

        public GuardarManejoCultivoResponse Modificar(int id, ManejoCultivo manejoCultivo){
            try{
                var manejoCultivoB = _context.ManejoCultivos.Find(id);
                if(manejoCultivoB == null){
                    return new GuardarManejoCultivoResponse("Error el manejo cultivo no se encuentra registrado");
                }

                manejoCultivoB.Lote = manejoCultivo.Lote;
                manejoCultivoB.Variedad = manejoCultivo.Variedad;
                manejoCultivoB.NumeroArboles = manejoCultivo.NumeroArboles;
                manejoCultivoB.SistemaRenovacion = manejoCultivo.SistemaRenovacion;
                manejoCultivoB.FechaSiembra = manejoCultivo.FechaSiembra;
                manejoCultivoB.DistanciaSiembra = manejoCultivo.DistanciaSiembra;

                _context.ManejoCultivos.Update(manejoCultivoB);                
                _context.SaveChanges();
                return new GuardarManejoCultivoResponse(manejoCultivo);
            }catch(Exception e){ 
                return new GuardarManejoCultivoResponse($"Error de la aplicacion: {e.Message}");
            }
        }

        public List<ManejoCultivo> ConsultarTodos(int id){  
            List<ManejoCultivo> datos = _context.ManejoCultivos.Where(d => d.AgroclimaticaId == id).ToList();
            return datos;
        }
    }

    public class GuardarManejoCultivoResponse 
    {
        public GuardarManejoCultivoResponse(ManejoCultivo objeto1)
        {
            Error = false;
            objeto = objeto1;
        }
        public GuardarManejoCultivoResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public ManejoCultivo objeto { get; set; }
    }
}
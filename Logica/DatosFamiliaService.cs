using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;

namespace Logica
{
    public class DatosFamiliaService
    {
        private readonly SyscscContext _context;

        public DatosFamiliaService(SyscscContext context)
        {
            _context = context;
        }

        public GuardarDatosFamiliaResponse Guardar(DatosFamilia datosFamilia){
            try{
                var datosFamiliaB = _context.DatosFamilias.Find(datosFamilia.Identificacion);
                if(datosFamiliaB != null){
                    return new GuardarDatosFamiliaResponse("Error el datos Familia ya se encuentra registrado");
                }
                var p = _context.Proveedores.Find(datosFamilia.ProveedorId);                
                p.DatosFamilias.Add(datosFamilia);
                _context.SaveChanges();
                return new GuardarDatosFamiliaResponse(datosFamilia);
            }catch(Exception e){ 
                return new GuardarDatosFamiliaResponse($"Error de la aplicacion: {e.Message}");
            }
        }

        public GuardarDatosFamiliaResponse Modificar(int id, DatosFamilia datosFamilia){
            try{
                var datosFamiliaB = _context.DatosFamilias.Find(id);
                if(datosFamiliaB == null){
                    return new GuardarDatosFamiliaResponse("Error el datos Familia no se encuentra registrado");
                }

                //var p = _context.Proveedores.Find(datosFamilia.ProveedorId);  
                datosFamiliaB.Nombre = datosFamilia.Nombre;
                datosFamiliaB.FechaNacimiento = datosFamilia.FechaNacimiento;
                datosFamiliaB.Parentesco = datosFamilia.Parentesco;
                datosFamiliaB.TipoPoblacion = datosFamilia.TipoPoblacion;
                datosFamiliaB.AfilicionSalud = datosFamilia.AfilicionSalud;
                datosFamiliaB.NivelEducativo = datosFamilia.NivelEducativo;

                _context.DatosFamilias.Update(datosFamiliaB);                
                _context.SaveChanges();
                return new GuardarDatosFamiliaResponse(datosFamilia);
            }catch(Exception e){ 
                return new GuardarDatosFamiliaResponse($"Error de la aplicacion: {e.Message}");
            }
        }

        public List<DatosFamilia> ConsultarTodos(int id){  
            List<DatosFamilia> datosFamilias = _context.DatosFamilias.Where(d => d.ProveedorId == id).ToList();
            return datosFamilias;
        }
    }

    public class GuardarDatosFamiliaResponse 
    {
        public GuardarDatosFamiliaResponse(DatosFamilia objeto1)
        {
            Error = false;
            objeto = objeto1;
        }
        public GuardarDatosFamiliaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public DatosFamilia objeto { get; set; }
    }
}
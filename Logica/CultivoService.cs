using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;

namespace Logica
{
    public class CultivoService
    {
        private readonly SyscscContext _context;

        public CultivoService(SyscscContext context)
        {
            _context = context;
        }

        public GuardarCultivoResponse Guardar(Cultivo cultivo){
            try{
                /*var cultivoBuscado = _context.Cultivos.Find(cultivo.NumeroCedula);
                if(cultivoBuscado != null){
                    return new GuardarCultivoResponse("Error el cultivo ya se encuentra registrado");
                }*/

                _context.Cultivos.Add(cultivo);
                _context.SaveChanges();
                return new GuardarCultivoResponse(cultivo);
            }catch(Exception e){ 
                return new GuardarCultivoResponse($"Error de la aplicacion: {e.Message}");
            }
        }

        public GuardarCultivoResponse Modificar(int id, Cultivo cultivo){
            try{
                var cultivoBuscado = _context.Cultivos.Find(id);
                if(cultivoBuscado == null){
                    return new GuardarCultivoResponse("Error el cultivo no se encuentra registrado");
                }
                cultivoBuscado.Nombre = cultivo.Nombre;
                _context.Cultivos.Update(cultivoBuscado);
                _context.SaveChanges();
                return new GuardarCultivoResponse(cultivo);
            }catch(Exception e){ 
                return new GuardarCultivoResponse($"Error de la aplicacion: {e.Message}");
            }
        }

        public List<Cultivo> ConsultarTodos(){  
            List<Cultivo> cultivos = _context.Cultivos.ToList();
            return cultivos;
        }
    }

    public class GuardarCultivoResponse 
    {
        public GuardarCultivoResponse(Cultivo cultivo1)
        {
            Error = false;
            cultivo = cultivo1;
        }
        public GuardarCultivoResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Cultivo cultivo { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Entity
{
    public class Productor
    {
        [Key]
        public int ProductorId { get; set; }
        public int MunicipioId { get; set; }
        public Municipio Municipio { get; set; }    
        public Agroclimatica Agroclimatica { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }                
        public string CedulaCafetera { get; set; }
        public string NombrePredio { get; set; }
        public string CodigoFinca { get; set; }
        public string CodigoSICA { get; set; }
        
        public string Actividades { get; set; }
        public string Telefono { get; set; }
        public string AfiliacionSalud { get; set; }

        public List<DatosFamilia> DatosFamilias { get; } = new List<DatosFamilia>();
        public List<InsumoExterno> InsumoExternos { get; } = new List<InsumoExterno>();
        public List<InsumoInterno> InsumoInternos { get; } = new List<InsumoInterno>();
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class DatosFamilia
    {
        [Key]
        public int Identificacion { get; set; }
        public int ProveedorId { get; set; }
        public string Nombre { get; set; }
        public string FechaNacimiento { get; set; }
        public string Parentesco { get; set; }
        public string TipoPoblacion { get; set; }
        public string AfilicionSalud { get; set; }
        public string NivelEducativo { get; set; }
    }
}
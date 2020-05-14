using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class InsumoExterno
    {
        [Key]
        public int InsumoExternoId { get; set; }
        public int ProveedorId { get; set; }
        public string Nombre { get; set; }
        public string Fabricante { get; set; }
        public string RegistroICA { get; set; }
        public string Composicion { get; set; }
        public string Dosis { get; set; }
        public string Cantidad { get; set; }
        public string FechaAplicacion { get; set; }
        public string LugarAplicacion { get; set; }
    }
}
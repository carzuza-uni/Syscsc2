using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class InsumoInterno
    {
        [Key]
        public int InsumoInternoId { get; set; }
        public int ProductorId { get; set; }
        public string Nombre { get; set; }
        public string MaterialesUsado { get; set; }
        public string Procedimiento { get; set; }
        public string TiempoPreparacion { get; set; }
        public string MetodoPreparacion { get; set; }
        public string Dosis { get; set; }
        public string Cantidad { get; set; }
        public string FechaAplicacion { get; set; }
        public string LugarAplicacion { get; set; }
    }
}
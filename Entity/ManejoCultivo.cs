using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class ManejoCultivo
    {
        [Key]
        public int ManejoCultivoId { get; set; }
        public int AgroclimaticaId { get; set; }
        public string Lote { get; set; }
        public string Variedad { get; set; }
        public string NumeroArboles { get; set; }
        public string SistemaRenovacion { get; set; }
        public string FechaSiembra { get; set; }
        public string DistanciaSiembra { get; set; }
    }
}
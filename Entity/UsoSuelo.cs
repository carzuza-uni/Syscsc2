using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class UsoSuelo
    {
        [Key]
        public int UsoSueloId { get; set; }
        public int AgroclimaticaId { get; set; }
        public string Lote { get; set; }
        public decimal Area { get; set; }
        public string Usos { get; set; }
        public string Sombrio { get; set; }
        public string PlanteadoProximoAno { get; set; }
        public string Pendiente { get; set; }
        public string PresentaErosion { get; set; }
    }
}
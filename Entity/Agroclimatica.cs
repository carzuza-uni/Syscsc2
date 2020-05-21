using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Agroclimatica
    {
        [Key]
        public int AgroclimaticaId { get; set; }
        public int ProductorId { get; set; }
        public string Latitud { get; set; }
        public string NorteLongitud { get; set; }
        public string Este { get; set; }
        public string MSNM { get; set; }
        public string AnalisisSuelo { get; set; }
        public string FechaRealizacion { get; set; }
        public string PlanFertilizacion { get; set; }
        public string TipoTextura { get; set; }
        public string PreparacionAbono { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
    }
}
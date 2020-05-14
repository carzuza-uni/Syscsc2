using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Municipio
    {
        [Key]
        public int CultivoId { get; set; }
        [Required]
        public string Nombre { get; set; }   
    }
}
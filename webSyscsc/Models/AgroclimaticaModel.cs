using Entity;

namespace webSyscsc.Models
{
    public class AgroclimaticaInputModel
    {
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

    public class AgroclimaticaViewModel : AgroclimaticaInputModel
    {
        public AgroclimaticaViewModel()
        {

        }
        public AgroclimaticaViewModel(Agroclimatica agroclimatica)
        {
            AgroclimaticaId = agroclimatica.AgroclimaticaId;
            ProductorId = agroclimatica.ProductorId;
            Latitud = agroclimatica.Latitud;
            NorteLongitud = agroclimatica.NorteLongitud;
            Este = agroclimatica.Este;
            MSNM = agroclimatica.MSNM;
            AnalisisSuelo = agroclimatica.AnalisisSuelo;
            FechaRealizacion = agroclimatica.FechaRealizacion;
            PlanFertilizacion = agroclimatica.PlanFertilizacion;
            TipoTextura = agroclimatica.TipoTextura;
            PreparacionAbono = agroclimatica.PreparacionAbono;
            Tipo = agroclimatica.Tipo;
            Estado = agroclimatica.Estado;
            Observaciones = agroclimatica.Observaciones;
        }
    }
}
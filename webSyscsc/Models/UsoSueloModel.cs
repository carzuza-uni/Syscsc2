using Entity;

namespace webSyscsc.Models
{
    public class UsoSueloInputModel
    {
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

    public class UsoSueloViewModel : UsoSueloInputModel
    {
        public UsoSueloViewModel()
        {

        }
        public UsoSueloViewModel(UsoSuelo usoSuelo)
        {
            UsoSueloId = usoSuelo.UsoSueloId;
            AgroclimaticaId = usoSuelo.AgroclimaticaId;
            Lote = usoSuelo.Lote;
            Area = usoSuelo.Area;
            Usos = usoSuelo.Usos;
            Sombrio = usoSuelo.Sombrio;
            PlanteadoProximoAno = usoSuelo.PlanteadoProximoAno;
            Pendiente = usoSuelo.Pendiente;
            PresentaErosion = usoSuelo.PresentaErosion;
        }
    }
}
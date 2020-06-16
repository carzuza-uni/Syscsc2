using Entity;

namespace webSyscsc.Models
{
    public class ManejoCultivoInputModel
    {
        public int ManejoCultivoId { get; set; }
        public int AgroclimaticaId { get; set; }
        public string Lote { get; set; }
        public string Variedad { get; set; }
        public string NumeroArboles { get; set; }
        public string SistemaRenovacion { get; set; }
        public string FechaSiembra { get; set; }
        public string DistanciaSiembra { get; set; }
    }

    public class ManejoCultivoViewModel : ManejoCultivoInputModel
    {
        public ManejoCultivoViewModel()
        {

        }
        public ManejoCultivoViewModel(ManejoCultivo manejoCultivo)
        {
            ManejoCultivoId = manejoCultivo.ManejoCultivoId;
            AgroclimaticaId = manejoCultivo.AgroclimaticaId;
            Lote = manejoCultivo.Lote;
            Variedad = manejoCultivo.Variedad;
            NumeroArboles = manejoCultivo.NumeroArboles;
            SistemaRenovacion = manejoCultivo.SistemaRenovacion;
            FechaSiembra = manejoCultivo.FechaSiembra;
            DistanciaSiembra = manejoCultivo.DistanciaSiembra;
        }
    }
}
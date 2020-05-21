using Entity;

namespace webSyscsc.Models
{
    public class DatosFamiliaInputModel
    {
        public int Identificacion { get; set; }
        public int ProductorId { get; set; }
        public string Nombre { get; set; }
        public string FechaNacimiento { get; set; }
        public string Parentesco { get; set; }
        public string TipoPoblacion { get; set; }
        public string AfilicionSalud { get; set; }
        public string NivelEducativo { get; set; }
    }

    public class DatosFamiliaViewModel : DatosFamiliaInputModel
    {
        public DatosFamiliaViewModel()
        {

        }
        public DatosFamiliaViewModel(DatosFamilia datosFamilia)
        {
            Identificacion = datosFamilia.Identificacion;
            ProductorId = datosFamilia.ProductorId;
            Nombre = datosFamilia.Nombre;
            FechaNacimiento = datosFamilia.FechaNacimiento;
            Parentesco = datosFamilia.Parentesco;
            TipoPoblacion = datosFamilia.TipoPoblacion;
            AfilicionSalud = datosFamilia.AfilicionSalud;
            NivelEducativo = datosFamilia.NivelEducativo;

        }
    }
}
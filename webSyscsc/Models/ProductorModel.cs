using Entity;

namespace webSyscsc.Models
{
    public class ProductorInputModel
    {
        public int ProveedorId { get; set; }
        public int MunicipioId { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string CedulaCafetera { get; set; }
        public string NombrePredio { get; set; }
        public string CodigoFinca { get; set; }
        public string CodigoSICA { get; set; }        
        public string Actividades { get; set; }
        public string Telefono { get; set; }
        public string AfiliacionSalud { get; set; }
    }

    public class ProductorViewModel : ProductorInputModel
    {
        public ProductorViewModel()
        {

        }
        public ProductorViewModel(Proveedor productor)
        {
            ProveedorId = productor.ProveedorId;
            MunicipioId = productor.MunicipioId;
            Nombre = productor.Nombre;
            Cedula = productor.Cedula;
            CedulaCafetera = productor.CedulaCafetera;
            NombrePredio = productor.NombrePredio;
            CodigoFinca = productor.CodigoFinca;
            CodigoSICA = productor.CodigoSICA;
            Actividades = productor.Actividades;
            Telefono = productor.Telefono;
            AfiliacionSalud = productor.AfiliacionSalud;
        }
    }
}
using Entity;

namespace webSyscsc.Models
{
    public class InsumoExternoInputModel
    {
        public int InsumoExternoId { get; set; }
        public int ProductorId { get; set; }
        public string Nombre { get; set; }
        public string Fabricante { get; set; }
        public string RegistroICA { get; set; }
        public string Composicion { get; set; }
        public string Dosis { get; set; }
        public string Cantidad { get; set; }
        public string FechaAplicacion { get; set; }
        public string LugarAplicacion { get; set; }
    }

    public class InsumoExternoViewModel : InsumoExternoInputModel
    {
        public InsumoExternoViewModel()
        {

        }
        public InsumoExternoViewModel(InsumoExterno insumoExterno)
        {
            InsumoExternoId = insumoExterno.InsumoExternoId;
            ProductorId = insumoExterno.ProductorId;
            Nombre = insumoExterno.Nombre;
            Fabricante = insumoExterno.Fabricante;
            RegistroICA = insumoExterno.RegistroICA;
            Composicion = insumoExterno.Composicion;
            Dosis = insumoExterno.Dosis;
            Cantidad = insumoExterno.Cantidad;
            FechaAplicacion = insumoExterno.FechaAplicacion;
            LugarAplicacion = insumoExterno.LugarAplicacion;
        }
    }
}
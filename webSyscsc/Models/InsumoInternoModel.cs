using Entity;

namespace webSyscsc.Models
{
    public class InsumoInternoInputModel
    {
        public int InsumoInternoId { get; set; }
        public int ProductorId { get; set; }
        public string Nombre { get; set; }
        public string MaterialesUsado { get; set; }
        public string Procedimiento { get; set; }
        public string TiempoPreparacion { get; set; }
        public string MetodoPreparacion { get; set; }
        public string Dosis { get; set; }
        public string Cantidad { get; set; }
        public string FechaAplicacion { get; set; }
        public string LugarAplicacion { get; set; }
    }

    public class InsumoInternoViewModel : InsumoInternoInputModel
    {
        public InsumoInternoViewModel()
        {

        }
        public InsumoInternoViewModel(InsumoInterno insumoInterno)
        {
            InsumoInternoId = insumoInterno.InsumoInternoId;
            ProductorId = insumoInterno.ProductorId;
            Nombre = insumoInterno.Nombre;
            MaterialesUsado = insumoInterno.MaterialesUsado;
            Procedimiento = insumoInterno.Procedimiento;
            TiempoPreparacion = insumoInterno.TiempoPreparacion;
            MetodoPreparacion = insumoInterno.MetodoPreparacion;
            Dosis = insumoInterno.Dosis;
            Cantidad = insumoInterno.Cantidad;
            FechaAplicacion = insumoInterno.FechaAplicacion;
            LugarAplicacion = insumoInterno.LugarAplicacion;
        }
    }
}
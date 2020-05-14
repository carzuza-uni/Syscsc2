using Entity;

namespace webSyscsc.Models
{
    public class CultivoInputModel
    {
        public int CultivoId { get; set; }
        public string Nombre { get; set; }
    }

    public class CultivoViewModel : CultivoInputModel
    {
        public CultivoViewModel()
        {

        }
        public CultivoViewModel(Cultivo cultivo)
        {
            CultivoId = cultivo.CultivoId;
            Nombre = cultivo.Nombre;
        }
    }
}
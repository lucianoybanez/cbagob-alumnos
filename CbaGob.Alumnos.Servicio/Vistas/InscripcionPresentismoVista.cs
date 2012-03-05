using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class InscripcionPresentismoVista :IInscripcionPresentismoVista
    {
        public int IdPresentismo { get; set; }
        public int IdInscripcion { get; set; }
        public int ClasesAsistidas { get; set; }
        public decimal PorcentajePresentismo { get; set; }
    }
}
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class InscripcionPresentismoVista : IInscripcionPresentismoVista
    {
        public int IdPresentismo { get; set; }
        public int IdInscripcion { get; set; }
        public int ClasesAsistidas { get; set; }
        public decimal PorcentajePresentismo
        {
            get
            {
                if (TotalClasesCurso == 0 || ClasesAsistidas==0)
                {
                    return 0;
                }
                else
                {
                    decimal valor1 = decimal.Divide(ClasesAsistidas, TotalClasesCurso);
                    decimal valor = valor1 * 100;
                    return decimal.Round(valor);
                }

            }
        }
        public int TotalClasesCurso { get; set; }
    }
}
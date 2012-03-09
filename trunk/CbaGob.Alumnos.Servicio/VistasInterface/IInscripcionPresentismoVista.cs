namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IInscripcionPresentismoVista 
    {
        int IdPresentismo { get; set; }
        int IdInscripcion { get; set; }
        int ClasesAsistidas { get; set; }
        decimal PorcentajePresentismo { get; }
        int TotalClasesCurso { get; set; }
    }
}
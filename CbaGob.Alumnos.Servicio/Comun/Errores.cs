namespace CbaGob.Alumnos.Servicio.Comun
{
    public class Errores : IErrores
    {
        public TypeError TypeError { get; set; }
        public string Message { get; set; }
    }
}

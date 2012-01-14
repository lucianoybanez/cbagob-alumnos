namespace CbaGob.Alumnos.Servicio.Common
{
    public class Errors : IErrors
    {
        public TypeError TypeError { get; set; }
        public string Message { get; set; }
    }
}

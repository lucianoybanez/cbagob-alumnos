using CbaGob.Alumnos.Infra;

namespace CbaGob.Alumnos.Servicio.Comun
{
    public enum TypeError
    {
        [StringValue("Not Exist")]
        NotExist,
        None
    }

    public interface IErrores
    {
        TypeError TypeError { get; set; }
        string Message { get; set; }
    }
}
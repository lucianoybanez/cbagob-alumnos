using CbaGob.Alumnos.Infra;

namespace CbaGob.Alumnos.Servicio.Common
{
    public enum TypeError
    {
        [StringValue("Not Exist")]
        NotExist,
        None
    }

    public interface IErrors
    {
        TypeError TypeError { get; set; }
        string Message { get; set; }
    }
}
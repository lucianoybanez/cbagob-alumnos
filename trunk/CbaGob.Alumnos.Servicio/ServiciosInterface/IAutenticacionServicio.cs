namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IAutenticacionServicio : IBaseServicio
    {
        bool IsAccountValid(string username, string password);
    }
}

namespace CbaGob.Alumnos.Servicio.ServicesInterface
{
    public interface IUserService : IBaseService
    {
        bool IsAccountValid(string username, string password);
    }
}

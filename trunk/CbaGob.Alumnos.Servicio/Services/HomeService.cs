using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Servicio.Common;
using CbaGob.Alumnos.Servicio.ServicesInterface;
using CbaGob.Alumnos.Servicio.Views;
using CbaGob.Alumnos.Servicio.ViewsInterface;

namespace CbaGob.Alumnos.Servicio.Services
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class HomeService : BaseService, IHomeService
    {
        private IUserRepository userRepository;

        public HomeService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IHomeView GetDefault()
        {
            IHomeView myView = new HomeView();
            myView.FirstUser = userRepository.GetUserById(1).Name;
            return myView;
        }
    }
}

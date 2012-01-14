using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Servicio.Common;
using CbaGob.Alumnos.Servicio.ServicesInterface;

namespace CbaGob.Alumnos.Servicio.Services
{
    public class UserService :BaseService, IUserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public bool IsAccountValid(string username, string password)
        {
            bool ret = false;
            var user = userRepository.GetUserByNamePassword(username, password);
            if (user==null)
            {
                AddError(TypeError.NotExist,"The User don't exist.");
            }
            else
            {
                ret = true;
            }
            return ret;
        }

        public IList<IErrors> GetErrors()
        {
            return base.Errors;
        }
    }
}
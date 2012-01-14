using System.Collections.Generic;

namespace CbaGob.Alumnos.Servicio.Common
{
    public class BaseService
    {
        private IList<IErrors> _errors = new List<IErrors>();

        public IList<IErrors> Errors
        {
            get { return _errors; }
        }

        public void AddError(TypeError type, string message)
        {
            _errors.Add(new Errors() { Message = message ,TypeError = type});
        }

        public void AddError(string message)
        {
            _errors.Add(new Errors() { Message = message, TypeError = TypeError.None });
        }
    }
}

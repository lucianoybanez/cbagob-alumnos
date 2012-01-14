﻿using System.Collections.Generic;
using CbaGob.Alumnos.Servicio.Comun;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class BaseService
    {
        private IList<IErrores> _errors = new List<IErrores>();

        public IList<IErrores> Errors
        {
            get { return _errors; }
        }

        public void AddError(TypeError type, string message)
        {
            _errors.Add(new Errores() { Message = message ,TypeError = type});
        }

        public void AddError(string message)
        {
            _errors.Add(new Errores() { Message = message, TypeError = TypeError.None });
        }
    }
}

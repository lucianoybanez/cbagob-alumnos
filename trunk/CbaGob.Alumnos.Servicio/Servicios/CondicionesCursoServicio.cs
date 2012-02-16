using System;
using System.Collections.Generic;
using CbaGob.Alumnos.Servicio.Comun;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class CondicionesCursoServicio : BaseServicio, ICondicionesCursoServicio
    {
        public ICondicionesCursoVista GetByInstitucionId(int IdInstitucion)
        {
            throw new NotImplementedException();
        }

        public ICondicionCursoVista GetById(int IdCondicionCurso)
        {
            throw new NotImplementedException();
        }

        public IList<IErrores> GetErrors()
        {
            return base.Errors;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using CbaGob.Alumnos.Servicio.Comun;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class AreasTipoCursoServicio : BaseServicio, IAreasTipoCursoServicio
    {
        private IAreaTipoCursoRepositorio areatipocursorepositorio;


        public AreasTipoCursoServicio(IAreaTipoCursoRepositorio Areatipocursorepositorio)
        {
            areatipocursorepositorio = Areatipocursorepositorio;
        }


        public IAreasTipoCursoVista GetAreasTipoCurso()
        {
            try
            {
                IAreasTipoCursoVista Vista = new AreasTipoCursoVista();

                Vista.ListaAreaTipoCurso = areatipocursorepositorio.GetAreasTipoCurso();

                return Vista;
            }
            catch (Exception)
            {
                base.AddError("Sucedio un Error comprueb los datos");
                return null;

            }
        }

        public IList<IErrores> GetErrors()
        {
            return Errors;
        }
    }
}

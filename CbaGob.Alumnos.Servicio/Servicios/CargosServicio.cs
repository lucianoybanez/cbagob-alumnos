using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using CbaGob.Alumnos.Servicio.ServiciosInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class CargosServicio : ICargosServicio
    {
        private ICargosRepositorio cargosrepositorio;


        public CargosServicio()
        {
            cargosrepositorio = new CargosRepositorio();
        }

        public IList<ICargos> GetTodosCargos()
        {
            try
            {
                return cargosrepositorio.GetTodosCargos();
            }
            catch (Exception)
            {
                
                throw;
            }

        }
    }
}

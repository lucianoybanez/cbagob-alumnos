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
    public class DomiciliosServicios : IDomiciliosServicios
    {
        private IDomiciliosRepositorio domiciliosrepositorio; 



        public DomiciliosServicios()
        {
            domiciliosrepositorio = new DomiciliosRepositorio();
        }

        public IList<IDomicilios> GetTodosDomicilios()
        {
            try
            {
                return domiciliosrepositorio.GetTodosDomicilios();
            }
            catch (Exception)
            {
                
                throw;
            }

        }

        public IDomicilios GetUno(int id_domicilio)
        {
            try
            {
                return domiciliosrepositorio.GetUno(id_domicilio);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

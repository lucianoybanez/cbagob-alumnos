using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio.Models;

namespace CbaGob.Alumnos.Repositorio
{
    public class DomiciliosRepositorio : IDomiciliosRepositorio
    {
        private CursosDB mDB;

        public DomiciliosRepositorio()
        {
            mDB = new CursosDB();
        }

        public IList<IDomicilios> GetTodosDomicilios()
        {
            try
            {
                var ListaDomicilios = (from a in mDB.T_DOMICILIO
                                       select
                                           new Domicilios
                                               {
                                                   Id_Domicilio = a.ID_DOMICILIO,
                                                   Barrio = a.BARRIO,
                                                   Calle = a.CALLE,
                                                   Localidad = a.LOCALIDAD,
                                                   Nro = a.NRO,
                                                   Provincia = a.PROVINCIA
                                               }).ToList().Cast<IDomicilios>().ToList();

                return ListaDomicilios;
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
                var domicilios = (from a in mDB.T_DOMICILIO
                                  where a.ID_DOMICILIO == id_domicilio
                                  select
                                      new Domicilios
                                          {
                                              Id_Domicilio = a.ID_DOMICILIO,
                                              Barrio = a.BARRIO,
                                              Calle = a.CALLE,
                                              Localidad = a.LOCALIDAD,
                                              Nro = a.NRO,
                                              Provincia = a.PROVINCIA
                                          }).SingleOrDefault();

                return domicilios;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

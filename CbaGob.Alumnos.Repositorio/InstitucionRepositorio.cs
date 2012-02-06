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
    public class InstitucionRepositorio : IInstitucionRepositorio
    {
        public CursosDB mDb; 
        
        public InstitucionRepositorio()
        {
            mDb = new CursosDB();
        }

        public IList<IInstitucion> GetTodas()
        {
            try
            {
                IList<IInstitucion> ListRetorno = (from e in mDb.T_INSTITUCIONES
                                                   where e.ESTADO == "0"
                                                   select
                                                       new Institucion
                                                           {
                                                               FechaAlta = e.FEC_ALTA,
                                                               FechaModificacion = e.FEC_MODIF,
                                                               ID_CALLE = e.ID_CALLE,
                                                               ID_LOCALIDAD = e.ID_LOCALIDAD,
                                                               ID_PROVINCIA = e.ID_PROVINCIA,
                                                               INS_PROPIA = e.INS_PROPIA,
                                                               INST_ID = e.INST_ID,
                                                               INST_NOMBRE = e.INST_NOMBRE,
                                                               INST_NRO = e.INST_NRO,
                                                               INST_TELEFONO = e.INST_TELEFONO,
                                                               UsuarioAlta = e.USUARIO_ALTA,
                                                               UsuarioModificacion = e.USUARIO_MODIF
                                                           }).Cast<IInstitucion>()
                    .ToList();
                return ListRetorno;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public IInstitucion GetUna(int INST_ID)
        {
            throw new NotImplementedException();
        }

        public bool AgregarInstitucion(IInstitucion pInstitucion)
        {
            throw new NotImplementedException();
        }

        public bool ModificarInstitucion(IInstitucion pInstitucion)
        {
            throw new NotImplementedException();
        }

        public bool EliminarInstitucion(int INST_ID)
        {
            throw new NotImplementedException();
        }
    }
}

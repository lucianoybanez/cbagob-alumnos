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
    public class InstitucionServicio : IInstitucionServicio
    {
        private IInstitucionRepositorio InstitucionRepositorio;
        
        
        public InstitucionServicio()
        {
            InstitucionRepositorio = new InstitucionRepositorio();
        }
        
        
        
        public IList<IInstitucion> GetTodas()
        {
            try
            {
                return InstitucionRepositorio.GetTodas();
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

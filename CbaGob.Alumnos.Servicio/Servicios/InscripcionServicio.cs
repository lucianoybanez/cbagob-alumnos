using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class InscripcionServicio : IInscripcionServicio
    {
        private IInscripcionRepositorio inscripcionrepositorio;

        public InscripcionServicio()
        {
            inscripcionrepositorio = new InscripcionRepositorio();
        }

        public IInscripcionesVista GetAllInscripcion()
        {
            throw new NotImplementedException();
        }

        public IInscripcionesVista GetAllInscripcionByAlumno(int id_alumno)
        {
            throw new NotImplementedException();
        }

        public IInscripcionVista GetInscripcion(int id_inscripcion)
        {
            throw new NotImplementedException();
        }

        public bool AgregarInscripcion(IInscripcion inscripcion)
        {
            throw new NotImplementedException();
        }

        public bool ModificarInscripcion(IInscripcion inscripcion)
        {
            throw new NotImplementedException();
        }

        public bool EliminarInscripcion(int id_inscripcion)
        {
            throw new NotImplementedException();
        }
    }
}

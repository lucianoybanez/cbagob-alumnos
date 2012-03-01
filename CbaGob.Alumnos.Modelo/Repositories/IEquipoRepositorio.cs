using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface IEquipoRepositorio
    {
        IList<IEquipo> GetEquipos();
        IList<IEquipo> GetEquiposByEstado(int id_estado_equipo);
        IEquipo GetEquipo(int id_equipo);
        bool AgregarEquipo(IEquipo equipo);
        bool ModificarEquipo(IEquipo equipo);
        bool EliminarEquipo(int id_equipo);
        bool CambiarEstadoEquipo(int id_equipo, int id_estado_equipo);
    }
}

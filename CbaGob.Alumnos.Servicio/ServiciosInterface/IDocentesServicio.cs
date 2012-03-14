using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IDocentesServicio : IBaseServicio
    {
        IDocentesVista GetTodos();
        IDocentesVista GetIndex();
        IDocentesVista GetIndex(IPager page);
        IDocentesVista GetTodosByRazonSocial(string razonsocial);
        IDocentesVista GetDocentesNotInGrupo(int id_grupo);
        IDocentesVista GetDocentesInGrupo(int id_grupo);
        IDocentesVista GetUno(int id_docente);
        bool Agregar(IDocentesVista docente);
        bool Modificar(IDocentesVista docente);
        bool Eliminar(int id_docente, string nroresolucion);
        bool AsignarDocentes(int id_docente, int id_grupo, int id_condicion_curso);
        bool DesasignarDocentes(int id_docente, int id_grupo, int id_condicion_curso);
        IDocentesVista BuscarDocente(string razonsocial, string cuit_cuil);
    }
}

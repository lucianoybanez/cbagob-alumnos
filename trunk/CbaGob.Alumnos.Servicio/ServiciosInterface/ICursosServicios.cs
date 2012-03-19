using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface ICursosServicios : IBaseServicio
    {
        ICursosVista GetTodosbyInstitucion(int IdInstitucion);
        ICursosVista GetTodos();
        ICursos GetUno(int IdCurso);
        ICursosVista GetUnaVista(int id);
        ICursosVista GetTodos(IPager Pager);
        bool Agregar(ICursos pCursos);
        bool Modificar(ICursos pCursos);
        bool Eliminar(int IdCurso, string nroresulucion);
        ICursosVista GetVistaIndex();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface ISupervicionesRepositorio
    {
        IList<ISuperviciones> GetSuperviciones();
        IList<ISuperviciones> GetSuperviciones(int skip, int take);
        int GetCountSuperviciones();
        ISuperviciones GetSupervicion(int idsupervision);
        bool AgregarSuperviciones(ISuperviciones supervicion);
        bool ModificarSuperviciones(ISuperviciones supervicion);
        bool EliminarSuperviciones(int idsupervicion, string nro_resolucion);
    }
}

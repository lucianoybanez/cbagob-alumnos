using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface ITipo_SexoRepositorio
    {
        IList<ITipo_Sexo> GetTiposSexo();
    }
}

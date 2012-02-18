using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IPrograma
    {
        int IdPrograma { get; set; }
        string NombrePrograma { get; set; }
    }
}

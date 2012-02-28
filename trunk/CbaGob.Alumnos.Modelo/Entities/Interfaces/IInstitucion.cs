using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IInstitucion : IComunDatos
    {
        int Id_Institucion { get; set; }
        int Id_Domicilio { get; set; }
        string Nombre_Institucion { get; set; }
        string espropia { get; set; }
        string DireccionCompleta { get; set; }
    }
}

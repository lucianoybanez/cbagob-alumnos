using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IGruposVista
    {
        IList<IGrupo> ListaGrupos { get; set; }
        int Id_Condicion_Curso { get; set; }
    }
}

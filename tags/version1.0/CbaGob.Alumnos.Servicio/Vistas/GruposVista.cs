using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class GruposVista : IGruposVista
    {
        public IList<IGrupo> ListaGrupos { get; set; }
        public int Id_Condicion_Curso { get; set; }
    }
}

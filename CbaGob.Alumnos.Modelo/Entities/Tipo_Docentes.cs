using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Tipo_Docentes : ITipo_Docentes
    {
        public int Id_Tipo_Docente { get; set; }
        public string NombreTipoDocente { get; set; }
    }
}

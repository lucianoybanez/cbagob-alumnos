using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class EstadoCajaChica : IEstadoCajaChica
    {
        public int Id_Estado_Caja_Chica { get; set; }
        public string Nombre_estado { get; set; }
    }
}

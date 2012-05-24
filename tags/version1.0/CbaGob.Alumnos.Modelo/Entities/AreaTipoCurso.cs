﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class AreaTipoCurso : IAreaTipoCurso
    {
        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public string Estado { get; set; }
        public int Id_Area_Tipo_Curso { get; set; }
        public string Nombre_AreaTipoCurso { get; set; }
        public string Nro_Resolucion { get; set; }
    }
}

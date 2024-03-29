﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Grupo : IGrupo
    {
        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public string Estado { get; set; }
        public int Id_Grupo { get; set; }
        public int Id_Condicion_Curso { get; set; }
        public int Id_Establecimiento { get; set; }
        public int Id_Docente { get; set; }
        public int Id_Institucion { get; set; }
        public int Capacidad { get; set; }
        public string NombreGrupo { get; set; }
        public string NombreEstablecimiento { get; set; }
        public int Id_Domicilio { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public string Barrio { get; set; }
        public string Calle { get; set; }
        public int Nro { get; set; }
        public int Id_PersonaJuridica { get; set; }
        public string Cuit { get; set; }
        public string RazonSoial { get; set; }
        public DateTime Hr_Inicio { get; set; }
        public DateTime Hr_Fin { get; set; }
        public string Hr_DiaSemana { get; set; }
        public string Hr_Año { get; set; }
        public string Hr_Mes { get; set; }
        public string Nombre_Curso { get; set; }
        public string Nombre_Institucion { get; set; }
        public string Nro_Resolucion { get; set; }
    }
}

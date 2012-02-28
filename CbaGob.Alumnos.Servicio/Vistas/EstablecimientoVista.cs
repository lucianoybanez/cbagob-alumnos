﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class EstablecimientoVista : IEstablecimientoVista
    {
        public EstablecimientoVista()
        {
            DomicilioBuscador = new Buscador();
            InstitucionesBuscador = new Buscador();
        }

        public int Id_Establecimiento { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(1, 99999999999999999, ErrorMessage = "*")]
        public int Id_Institucion { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(1, 99999999999999999, ErrorMessage = "*")]
        public int Id_Domicilio { get; set; }

        [Required(ErrorMessage = "*")]
        public string NombreEstablecimiento { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public string Barrio { get; set; }
        public string Calle { get; set; }
        public string Nro { get; set; }
        public string DomicilioCompleto { get; set; }
        public string NombreInstitucion { get; set; }
        public IBuscador DomicilioBuscador { get; set; }
        public IBuscador InstitucionesBuscador { get; set; }
    }
}
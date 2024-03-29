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

        }

        public int Id_Establecimiento { get; set; }
        [Required(ErrorMessage = "*")]
        [Range(1, 99999999999999999, ErrorMessage = "*")]
        public int Id_Institucion { get; set; }
        [Required(ErrorMessage = "*")]
        public string NombreEstablecimiento { get; set; }
        [Required(ErrorMessage = "*")]
        public string Provincia { get; set; }
        [Required(ErrorMessage = "*")]
        public string Localidad { get; set; }
        [Required(ErrorMessage = "*")]
        public string Barrio { get; set; }
        [Required(ErrorMessage = "*")]
        public string Calle { get; set; }
        [Required(ErrorMessage = "*")]
        public int Nro { get; set; }
        [Required(ErrorMessage = "*")]
        public int Depto { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "*")]
        public string Emial { get; set; }
        [Required(ErrorMessage = "*")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "*")]
        public string Resposable { get; set; }
        public string DomicilioCompleto { get; set; }
        public string NombreInstitucion { get; set; }
        [Required(ErrorMessage = "*")]
        public string Nro_Resolucion { get; set; }
        public string TelefonoEstablecimiento { get; set; }
    }
}

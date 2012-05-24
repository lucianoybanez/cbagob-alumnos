using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.Vistas
{

    public class SupervisorVista : ISupervisorVista
    {

        public SupervisorVista()
        {

        }

        public int Id_Supervisor { get; set; }
        public string DomicilioCompleto { get; set; }
        public string DatosCompletoPersonajur { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public string Barrio { get; set; }
        public string Calle { get; set; }
        public int Nro { get; set; }
        [Required(ErrorMessage = "*")]
        public string Cuil_Cuit { get; set; }
        [Required(ErrorMessage = "*")]
        public string Razon_Social { get; set; }
        [Required(ErrorMessage = "*")]
        public string Nro_Resolucion { get; set; }
    }
}

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
            BuscadorDomicilio = new Buscador();
            BuscadorPersonaJur = new Buscador();
        }

        public int Id_Supervisor { get; set; }
        [Required(ErrorMessage = "*")]
        [Range(1, 99999999999999999, ErrorMessage = "*")]
        public int Id_PersonaJuridica { get; set; }
        [Required(ErrorMessage = "*")]
        [Range(1, 99999999999999999, ErrorMessage = "*")]
        public int Id_Domicilio { get; set; }
        public string DomicilioCompleto { get; set; }
        public string DatosCompletoPersonajur { get; set; }
        public string RazonSocial { get; set; }
        public string Cuit { get; set; }
        public IBuscador BuscadorDomicilio { get; set; }
        public IBuscador BuscadorPersonaJur { get; set; }
    }
}

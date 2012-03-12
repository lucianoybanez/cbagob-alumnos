using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Supervisores : ISupervisores
    {
        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public string Estado { get; set; }
        public int Id_Supervisor { get; set; }
        public int Id_PersonaJuridica { get; set; }
        public int Id_Domicilio { get; set; }
        public string DomicilioCompleto { get; set; }
        public string DatosCompletoPersonajur { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public string Barrio { get; set; }
        public string Calle { get; set; }
        public int Nro { get; set; }
        public string Cuil_Cuit { get; set; }
        public string Razon_Social { get; set; }
        public string Nro_Resolucion { get; set; }
    }
}

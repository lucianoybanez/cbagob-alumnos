using System;
using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Persona : IPersona
    {
        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public int PersonaId { get; set; }
        public string PersonaApellido { get; set; }
        public string PersonaNombre { get; set; }
        public int PersonaDni { get; set; }
        public int CargoTipo { get; set; }
        public DateTime PersonaNacimiento { get; set; }
        public string PersonaProvinciaNacimiento { get; set; }
        public string PersonaEmail { get; set; }
        public string IdSexo { get; set; }
        public string NroDocumento { get; set; }
        public string CodigoPais { get; set; }
        public decimal Numero { get; set; }
        public IList<IDireccion> Direcciones { get; set; }
        public IList<IFactura> Facturas { get; set; }
        public IList<IGrupo> Grupos { get; set; }
        public IList<ITelefono> Telefonos { get; set; }
        public IInstitucion Institucion { get; set; }
        public ISupervisor Supervisor { get; set; }
    }
}
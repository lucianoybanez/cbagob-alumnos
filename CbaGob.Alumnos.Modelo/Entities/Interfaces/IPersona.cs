using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IPersona : IComunDatos
    {
        int PersonaId { get; set; }
        string PersonaApellido { get; set; }
        string PersonaNombre { get; set; }
        int PersonaDni { get; set; }
        int CargoTipo { get; set; }
        DateTime PersonaNacimiento { get; set; }
        string PersonaProvinciaNacimiento { get; set; }
        string PersonaEmail { get; set; }
        string IdSexo { get; set; }
        string NroDocumento { get; set; }
        string CodigoPais { get; set; }
        decimal Numero { get; set; }
        IList<IDireccion> Direcciones { get; set; }
        IList<IFactura> Facturas { get; set; }
        IList<IGrupo> Grupos { get; set; }
        IList<ITelefono> Telefonos { get; set; }
        IInstitucion Institucion { get; set; }
        ISupervisor Supervisor { get; set; }

    }
}

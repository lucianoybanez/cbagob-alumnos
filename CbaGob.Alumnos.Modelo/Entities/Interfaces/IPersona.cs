using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IPersona : IComunDatos
    {
        int Id_Persona { get; set; }
        string Nov_Apellido { get; set; }
        string Nov_Nombre { get; set; }
        string Cuil { get; set; }
        DateTime Fecha_Nacimiento { get; set; }
        string Id_Sexo { get; set; }
        string Nro_Documento { get; set; }
        string Id_Tipo_Documento { get; set; }
        string Id_Estado_Civil { get; set; }
        string Estado { get; set; }
    }
}

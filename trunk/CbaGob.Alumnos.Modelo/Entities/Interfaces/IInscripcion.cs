using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IInscripcion : IComunDatos
    {
        int Id_Inscipcion { get; set; }
        int Id_Alumno { get; set; }
        int Id_Grupo { get; set; }
        System.DateTime Fecha { get; set; }
        string Nov_Apellido { get; set; }
        string Nov_Nombre { get; set; }
        string Cuil { get; set; }
        DateTime Fecha_Nacimiento { get; set; }
        string Nro_Documento { get; set; }
        string Nombre_Curso { get; set; }
        string Nombre_Grupo { get; set; }
        string Descripcion { get; set; }
    }
}

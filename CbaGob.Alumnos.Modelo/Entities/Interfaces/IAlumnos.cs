using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IAlumnos : IComunDatos
    {
        int Id_Alumno { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        string Nro_Documento { get; set; }
        System.DateTime Fecha_Nacimiento { get; set; }
        string Cuil { get; set; }
        int Id_Tipo_Dni { get; set; }
        int Id_Tipo_Estado_Civil { get; set; }
        int Id_Tipo_Sexo { get; set; }
        string Sexo { get; set; }
        string Estado_Civil { get; set; }
        string Tipo_Dni { get; set; }
        string Nro_Resolucion { get; set; }
        string Nro_Telefono { get; set; }
        string Nro_Celular { get; set; }
        string Provincia { get; set; }
        string Localidad { get; set; }
        string Barrio { get; set; }
        string Calle { get; set; }
        int Nro { get; set; }
        int Depto { get; set; }
    }
}

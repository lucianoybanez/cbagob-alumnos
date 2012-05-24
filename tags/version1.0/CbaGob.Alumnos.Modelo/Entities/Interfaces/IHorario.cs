using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IHorario : IComunDatos
    {
        int Id_Horario { get; set; }
        string Hora_Inicio { get; set; }
        string Hora_Fin { get; set; }
        string Dia_Semana { get; set; }
        string Año { get; set; }
        string Mes { get; set; }
        string Curso { get; set; }
        string Grupo { get; set; }
    }
}

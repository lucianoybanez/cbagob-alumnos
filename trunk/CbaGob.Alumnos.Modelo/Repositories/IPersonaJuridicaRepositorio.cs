using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface IPersonaJuridicaRepositorio
    {
        IList<IPersonaJuridica> GetTodasByRazonSocial(string razonsocial);
        IPersonaJuridica GetUno(int Id_PersonaJuridica);
        bool Agregar();
        bool Modificar();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio.Models;

namespace CbaGob.Alumnos.Repositorio
{
    public class EstablecimientoRepositorio : IEstablecimientoRepositorio
    {

        private CursosDB mDB;

        public EstablecimientoRepositorio()
        {
            mDB = new CursosDB();
        }

        public IList<IEstablecimiento> GetTodos()
        {
            try
            {
                var listaestablecimiento = (from c in mDB.T_ESTABLECIMINETOS
                                            where c.ESTADO == "A"
                                            select
                                                new Establecimiento
                                                    {
                                                        Estado = c.ESTADO,
                                                        FechaAlta = c.FEC_ALTA,
                                                        FechaModificacion = c.FEC_ALTA,
                                                        Id_Domicilio = c.ID_DOMICILIO,
                                                        Id_Establecimiento = c.ID_ESTABLECIMIENTO,
                                                        Id_Institucion = c.ID_INSTITUCION,
                                                        N_Establecimiento = c.N_ESTABLECIMIENTO,
                                                        UsuarioAlta = c.USR_ALTA,
                                                        UsuarioModificacion = c.USR_MODIF
                                                    }).ToList().Cast<IEstablecimiento>
                    ().ToList();
                return listaestablecimiento;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IList<IEstablecimiento> GetEstablecimientoByInstitucion(int id_institucion)
        {
            try
            {
                var listaestablecimiento = (from c in mDB.T_ESTABLECIMINETOS
                                            where c.ESTADO == "A" && c.ID_INSTITUCION == id_institucion
                                            select
                                                new Establecimiento
                                                {
                                                    Estado = c.ESTADO,
                                                    FechaAlta = c.FEC_ALTA,
                                                    FechaModificacion = c.FEC_ALTA,
                                                    Id_Domicilio = c.ID_DOMICILIO,
                                                    Id_Establecimiento = c.ID_ESTABLECIMIENTO,
                                                    Id_Institucion = c.ID_INSTITUCION,
                                                    N_Establecimiento = c.N_ESTABLECIMIENTO,
                                                    UsuarioAlta = c.USR_ALTA,
                                                    UsuarioModificacion = c.USR_MODIF
                                                }).ToList().Cast<IEstablecimiento>
                    ().ToList();
                return listaestablecimiento;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IEstablecimiento GetUno(int id_establecimiento)
        {
            try
            {
                var establecimiento = (from c in mDB.T_ESTABLECIMINETOS
                                       where c.ESTADO == "A" && c.ID_ESTABLECIMIENTO == id_establecimiento
                                       select
                                           new Establecimiento
                                               {
                                                   Estado = c.ESTADO,
                                                   FechaAlta = c.FEC_ALTA,
                                                   FechaModificacion = c.FEC_ALTA,
                                                   Id_Domicilio = c.ID_DOMICILIO,
                                                   Id_Establecimiento = c.ID_ESTABLECIMIENTO,
                                                   Id_Institucion = c.ID_INSTITUCION,
                                                   N_Establecimiento = c.N_ESTABLECIMIENTO,
                                                   UsuarioAlta = c.USR_ALTA,
                                                   UsuarioModificacion = c.USR_MODIF
                                               }).SingleOrDefault();
                return establecimiento;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool Agregar(IEstablecimiento establecimiento)
        {
            try
            {
                T_ESTABLECIMINETOS t_estableciento = new T_ESTABLECIMINETOS()
                                                         {
                                                             ESTADO = "A",
                                                             FEC_ALTA = System.DateTime.Now,
                                                             FEC_MODIF = System.DateTime.Now,
                                                             ID_DOMICILIO = establecimiento.Id_Domicilio,
                                                             ID_INSTITUCION = establecimiento.Id_Institucion,
                                                             N_ESTABLECIMIENTO = establecimiento.N_Establecimiento,
                                                             USR_ALTA = "Test",
                                                             USR_MODIF = "Test"
                                                         };

                mDB.AddToT_ESTABLECIMINETOS(t_estableciento);
                mDB.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Modificar(IEstablecimiento establecimiento)
        {
            try
            {
                var modestablecimiento = mDB.T_ESTABLECIMINETOS.FirstOrDefault(c => c.ID_ESTABLECIMIENTO == establecimiento.Id_Establecimiento);

                modestablecimiento.ID_DOMICILIO = establecimiento.Id_Domicilio;
                modestablecimiento.ID_INSTITUCION = establecimiento.Id_Institucion;
                modestablecimiento.N_ESTABLECIMIENTO = establecimiento.N_Establecimiento;
                modestablecimiento.USR_MODIF = "Test";
                modestablecimiento.FEC_MODIF = System.DateTime.Now;
                mDB.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(int id_establecimiento)
        {
            try
            {
                var modestablecimiento = mDB.T_ESTABLECIMINETOS.FirstOrDefault(c => c.ID_ESTABLECIMIENTO == id_establecimiento);

                modestablecimiento.ESTADO = "I";
                modestablecimiento.USR_MODIF = "Test";
                modestablecimiento.FEC_MODIF = System.DateTime.Now;
                mDB.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

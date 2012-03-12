using System;
using System.Collections.Generic;
using System.Linq;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio.Models;


namespace CbaGob.Alumnos.Repositorio
{
    public class UsuarioRepositorio : BaseRepositorio, IUsuarioRepositorio
    {
        private CursosDB mDb;

        public UsuarioRepositorio()
        {
            mDb = new CursosDB();
        }


        private IQueryable<IUsuario> QUsuario(string estado)
        {
            var a = (from u in mDb.T_USUARIO
                     where u.ESTADO == estado
                     select new Usuario()
                                {
                                    IdUsuario = u.ID_USUARIO,
                                    Rol = u.T_ROL.DESCRIPCION,
                                    NombreUsuario = u.NOMBRE,
                                    Password = u.PASSWORD,
                                    IdRol = u.T_ROL.ID_ROL
                                });
            return a;
        }


        public IUsuario GetUserById(int id)
        {
            return QUsuario("A").Where(c => c.IdUsuario == id).FirstOrDefault();
        }

        public IUsuario GetUserByNamePassword(string name, string password)
        {
            return QUsuario("A").Where(c => c.NombreUsuario.ToLower() == name.ToLower() && c.Password == password).SingleOrDefault();
        }

        public IUsuario GetUsersByName(string nombre, bool activo)
        {
            if (activo)
            {
                return QUsuario("A").Where(c => c.NombreUsuario == nombre).SingleOrDefault();
            }
            return QUsuario("I").Where(c => c.NombreUsuario == nombre).SingleOrDefault();
        }

        public IList<IUsuario> GetAllUsuarios(int skip, int take)
        {
            return QUsuario("A").OrderBy(c=> c.NombreUsuario).Skip(skip).Take(take).ToList();
        }

        public int GetAllUsuarios()
        {
            return QUsuario("A").Count();
        }

        public bool AgregarUsuario(IUsuario usuario)
        {
            try
            {
                base.AgregarDatosAlta(usuario);
                T_USUARIO mUsuario = new T_USUARIO();
                mUsuario.NOMBRE = usuario.NombreUsuario;
                mUsuario.PASSWORD = usuario.Password;
                mUsuario.FEC_ALTA = usuario.FechaAlta;
                mUsuario.FEC_MODIF = usuario.FechaModificacion;
                mUsuario.USR_ALTA = usuario.UsuarioAlta;
                mUsuario.USR_MODIF = usuario.UsuarioModificacion;
                mUsuario.ESTADO = usuario.Estado;
                mUsuario.ID_ROL = usuario.IdRol;
                mDb.AddToT_USUARIO(mUsuario);
                mDb.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool ModificarUsuario(IUsuario usuario)
        {
            try
            {
                base.AgregarDatosModificacion(usuario);
                T_USUARIO mUsuario = mDb.T_USUARIO.Where(c => c.ID_USUARIO == usuario.IdUsuario).FirstOrDefault();
                mUsuario.PASSWORD = usuario.Password;
                mUsuario.FEC_MODIF = usuario.FechaModificacion;
                mUsuario.USR_MODIF = usuario.UsuarioModificacion;
                mUsuario.ESTADO = usuario.Estado;
                mUsuario.ID_ROL = usuario.IdRol;
                mDb.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool EliminarUsuario(int usuario)
        {
            try
            { 
                IComunDatos datos = new ComunDatos();
                base.AgregarDatosEliminacion(datos);
                T_USUARIO mUsuario = mDb.T_USUARIO.Where(c => c.ID_USUARIO == usuario).FirstOrDefault();
                mUsuario.FEC_MODIF = datos.FechaModificacion;
                mUsuario.USR_MODIF = datos.UsuarioModificacion;
                mUsuario.ESTADO = datos.Estado;
                mDb.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IList<IRol> GetTodosRoles()
        {
            var result = (from rol in mDb.T_ROL
                          orderby rol.ID_ROL
                          select new Rol
                                     {
                                         Descripcion = rol.DESCRIPCION,
                                         RolId = rol.ID_ROL,
                                         Estado = rol.ESTADO,
                                         FechaAlta = rol.FEC_ALTA,
                                         FechaModificacion = rol.FEC_MODIF,
                                         UsuarioAlta = rol.USR_ALTA,
                                         UsuarioModificacion = rol.USR_MODIF
                                     }).ToList().Cast<IRol>().ToList();
            return result;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio.Models;

namespace CbaGob.Alumnos.Repositorio
{
    public class AlumnosRepositorio : IAlumnosRepositorio
    {
        public CursosDB mDb;


        public AlumnosRepositorio()
        {
            mDb = new CursosDB();
        }


        public IList<IAlumnos> GetTodos()
        {
            try
            {
                var ListaAlumno =
                    (from c in mDb.T_ALUMNOS
                     join e in mDb.T_PERSONAS on c.ID_PERSONA equals e.ID_PERSONA
                     where c.ESTADO == "A"
                     select
                         new Alumno
                             {
                                 Cuil = e.CUIL,
                                 Fecha_Nacimiento = e.FECHA_NACIMIENTO ?? System.DateTime.Now,
                                 Id_Alumno = c.ID_ALUMNO,
                                 Id_Persona = c.ID_PERSONA ?? 0,
                                 Id_Estado_Civil = e.ID_ESTADO_CIVIL,
                                 Id_Sexo = e.ID_SEXO,
                                 Id_Tipo_Documento = e.ID_TIPO_DOCUMENTO,
                                 Nov_Nombre = e.NOV_NOMBRE,
                                 Nov_Apellido = e.NOV_NOMBRE,
                                 Nro_Documento = e.NRO_DOCUMENTO
                             }).ToList().Cast<IAlumnos>().ToList();
                return ListaAlumno;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public IList<IAlumnos> GetTodosByNombreApellido(string nombre, string apellido)
        {
            throw new NotImplementedException();
        }

        public IList<IAlumnos> GetTodosByDni(string dni)
        {
            throw new NotImplementedException();
        }

        public IAlumnos GetUno(int id_alumno)
        {
            try
            {
                var alumno =
                    (from c in mDb.T_ALUMNOS
                     join e in mDb.T_PERSONAS on c.ID_PERSONA equals e.ID_PERSONA
                     where c.ESTADO == "A" && c.ID_ALUMNO == id_alumno
                     select
                         new Alumno
                             {
                                 Cuil = e.CUIL,
                                 Fecha_Nacimiento = e.FECHA_NACIMIENTO ?? System.DateTime.Now,
                                 Id_Alumno = c.ID_ALUMNO,
                                 Id_Persona = c.ID_PERSONA ?? 0,
                                 Id_Estado_Civil = e.ID_ESTADO_CIVIL,
                                 Id_Sexo = e.ID_SEXO,
                                 Id_Tipo_Documento = e.ID_TIPO_DOCUMENTO,
                                 Nov_Nombre = e.NOV_NOMBRE,
                                 Nov_Apellido = e.NOV_NOMBRE,
                                 Nro_Documento = e.NRO_DOCUMENTO
                             }).SingleOrDefault();
                return alumno;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Agregar(IAlumnos alumno)
        {
            try
            {
                T_ALUMNOS T_Alumnos = new T_ALUMNOS()
                                          {
                                              ESTADO = "A",
                                              FEC_ALTA = DateTime.Now,
                                              USR_ALTA = "Test",
                                              FEC_MODIF = DateTime.Now,
                                              USR_MODIF = "Test",
                                              ID_PERSONA = alumno.Id_Persona
                                          };


                mDb.AddToT_ALUMNOS(T_Alumnos);
                mDb.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Modificar(IAlumnos alumno)
        {
            try
            {
                var alu = mDb.T_ALUMNOS.FirstOrDefault(c => c.ID_ALUMNO == alumno.Id_Alumno);
                alu.ID_PERSONA = alumno.Id_Persona;
                alu.FEC_MODIF = System.DateTime.Now;
                alu.USR_MODIF = "Test";
                mDb.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(int id_alumno)
        {
            try
            {
                var alu = mDb.T_ALUMNOS.FirstOrDefault(c => c.ID_ALUMNO == id_alumno);
                alu.ESTADO = "I";
                alu.FEC_MODIF = System.DateTime.Now;
                alu.USR_MODIF = "Test";
                mDb.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
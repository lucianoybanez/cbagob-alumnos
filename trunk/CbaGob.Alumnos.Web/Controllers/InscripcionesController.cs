﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.VistasInterface;
using JLY.Hotel.Web.Controllers;

namespace CbaGob.Alumnos.Web.Controllers
{
    public class InscripcionesController : BaseController 
    {
        private IInscripcionServicio InscripcionServicio;

        private IExamenServicio ExamenServicio;

        public InscripcionesController(IInscripcionServicio inscripcionServicio, IExamenServicio examenServicio)
        {
            InscripcionServicio = inscripcionServicio;
            ExamenServicio = examenServicio;
        }

        public ActionResult Index()
        {
            return View(InscripcionServicio.GetAllInscripcion());
        }

        public ActionResult Agregar()
        {
            var vista = InscripcionServicio.GetInscripcion(0);
            vista.Accion = "Agregar";
            return View(vista);
        }

        public ActionResult Modificar(int idInscripcion)
        {
            var vista = InscripcionServicio.GetInscripcion(idInscripcion);
            vista.Accion = "Modificar";
            return View("Agregar",vista);
        }

        public ActionResult Ver(int idInscripcion)
        {
            var vista = InscripcionServicio.GetInscripcion(idInscripcion);
            var listaExamnes = ExamenServicio.GetExamenes(idInscripcion);
            vista.examens = listaExamnes;
            vista.Accion = "Ver";
            return View("Agregar", vista);
        }

        public ActionResult Eliminar(int idInscripcion)
        {
            var vista = InscripcionServicio.GetInscripcion(idInscripcion);
            vista.Accion = "Eliminar";
            return View("Agregar", vista);
        }

        public ActionResult Guardar(InscripcionVista vista)
        {
            bool result = false;
            if (vista.Accion == "Agregar")
            {
                result = InscripcionServicio.AgregarInscripcion(vista);
            }
            else if (vista.Accion == "Modificar")
            {
                result = InscripcionServicio.ModificarInscripcion(vista);
            }
            if (!result)
            {
                base.AddError(InscripcionServicio.GetErrors());
                return View("Agregar", vista);
            }
            return RedirectToAction("Index");
        }

        public ActionResult GuardarEliminacion(int IdInscripcion)
        {
            if (!InscripcionServicio.EliminarInscripcion(IdInscripcion))
            {
                base.AddError(InscripcionServicio.GetErrors());
                return RedirectToAction("Eliminar", IdInscripcion);
            }
            return RedirectToAction("Index");
        }

        public ActionResult CambioCambo(InscripcionVista vista)
        {
            return null;
        }

    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CbaGob.Alumnos.Servicio.Servicios;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.VistasInterface;
using JLY.Hotel.Web.Controllers;

namespace CbaGob.Alumnos.Web.Controllers
{
    public class EstablecimientosController : BaseController
    {
        private IEstablecimientoServicio establecimientoservicio;
        private IDomiciliosServicios domiciliosservicios;
        private IInstitucionServicio institucionservicio;

        //
        // GET: /Establecimientos/

        public EstablecimientosController()
        {
            establecimientoservicio = new EstablecimientoServicio();
            domiciliosservicios = new DomiciliosServicios();
            institucionservicio = new InstitucionServicio();

        }

        public ActionResult Index()
        {
            IEstablecimientosVista model = new EstablecimientosVista();

            model = establecimientoservicio.GetAllEstablecimiento();

            return View(model);
        }

        public ActionResult Agregar(int Id_institucion)
        {

            IEstablecimientoVista model = new EstablecimientoVista();

            model.Id_Institucion = Id_institucion;

            model.NombreInstitucion = institucionservicio.GetUnaVista(Id_institucion).Nombre_Institucion;


            model.DomicilioBuscador.Tipo = "Domicilios";
            model.DomicilioBuscador.Name = "BuDomicilio";

            model.InstitucionesBuscador.Tipo = "Instituciones";
            model.InstitucionesBuscador.Name = "BuInstituciones";

            return View(model);
        }


        public ActionResult Modificar(int id_establecimiento)
        {
            IEstablecimientoVista model;

            model = establecimientoservicio.GetEstablecimiento(id_establecimiento);

            model.DomicilioBuscador.Tipo = "Domicilios";
            model.DomicilioBuscador.Name = "BuDomicilio";
            model.DomicilioBuscador.Valor = model.DomicilioCompleto;

            model.InstitucionesBuscador.Tipo = "Instituciones";
            model.InstitucionesBuscador.Name = "BuInstituciones";
            model.InstitucionesBuscador.Valor = model.NombreInstitucion;

            return View(model);
        }

        public ActionResult Eliminar(int id_establecimiento)
        {
            IEstablecimientoVista model;

            model = establecimientoservicio.GetEstablecimiento(id_establecimiento);

            return View(model);
        }

        [HttpPost]
        public ActionResult Agregar_Establecimiento(EstablecimientoVista model)
        {

            model.Id_Institucion = model.Id_Institucion;
            bool mRet = establecimientoservicio.AgregarEstablecimiento(model);

            if (mRet == true)
            {
            IEstablecimientosVista establecimientosvista = new EstablecimientosVista();

            establecimientosvista = establecimientoservicio.GetAllEstablecimiento();

            return RedirectToAction("Ver", "Instituciones", new { INST_ID = model.Id_Institucion });
            }
            else
            {
                base.AddError(establecimientoservicio.GetErrors());
                model.Id_Institucion = model.Id_Institucion;
                model.NombreInstitucion = institucionservicio.GetUnaVista(model.Id_Institucion).Nombre_Institucion;
                model.DomicilioBuscador.Tipo = "Domicilios";
                model.DomicilioBuscador.Name = "BuDomicilio";
                model.InstitucionesBuscador.Tipo = "Instituciones";
                model.InstitucionesBuscador.Name = "BuInstituciones";
                return View("Agregar", model);
            }
        }

        [HttpPost]
        public ActionResult Eliminar_Establecimiento(EstablecimientoVista model)
        {


            bool mRet = establecimientoservicio.EliminarEstablecimiento(model.Id_Establecimiento);

            IEstablecimientosVista establecimientosvista = new EstablecimientosVista();

            establecimientosvista = establecimientoservicio.GetAllEstablecimiento();

            return RedirectToAction("Ver", "Instituciones", new { INST_ID = model.Id_Institucion });
        }

        [HttpPost]
        public ActionResult Modificar_Establecimiento(EstablecimientoVista model)
        {

            model.Id_Institucion = model.Id_Institucion;
            bool mRet = establecimientoservicio.ModificarEstablecimiento(model);

            IEstablecimientosVista establecimientosvista = new EstablecimientosVista();

            establecimientosvista = establecimientoservicio.GetAllEstablecimiento();

            return RedirectToAction("Ver", "Instituciones", new { INST_ID = model.Id_Institucion });

        }

    }
}

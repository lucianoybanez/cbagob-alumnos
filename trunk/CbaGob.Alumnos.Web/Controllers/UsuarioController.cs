using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Servicio.Servicios;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using JLY.Hotel.Web.Controllers;

namespace CbaGob.Alumnos.Web.Controllers
{
    public class UsuarioController : BaseController
    {
        private IUsuarioServicio UsuarioServicio;

        public UsuarioController(IUsuarioServicio usuarioServicio)
        {
            UsuarioServicio = usuarioServicio;
        }

        public ActionResult Index()
        {
            return View("Index", UsuarioServicio.GetAllUsuarios(null));
        }

        public ActionResult IndexPager(Pager pager, string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return View("Index", UsuarioServicio.GetAllUsuarios(pager));
            }
            return View("Index", UsuarioServicio.GetUsuario(nombre));
        }

        public ActionResult Agregar()
        {
            var vista = UsuarioServicio.GetUsuario(0);
            vista.Accion = "Alta";
            return View("Agregar", vista);
        }

        public ActionResult Modificar(int idUsuario)
        {
            var vista = UsuarioServicio.GetUsuario(idUsuario);
            vista.Accion = "Modificar";
            return View("Agregar", vista);
        }

        public ActionResult Eliminar(int idUsuario)
        {
            var vista = UsuarioServicio.GetUsuario(idUsuario);
            vista.Accion = "Eliminar";
            return View("Agregar", vista);
        }

        [HttpPost]
        public ActionResult GuardarUsuario(UsuarioVista vista)
        {
            bool result = false;
            if (vista.Accion == "Alta" || vista.Accion == "Modificar")
            {
                result = UsuarioServicio.GuardarUsuario(vista);
            }
            else if (vista.Accion == "Eliminar")
            {
                result = UsuarioServicio.EliminarUsuario(vista.idUsuario);
            }
            if (!result)
            {
                base.AddError(UsuarioServicio.GetErrors());
                vista.Roles = UsuarioServicio.GetRoles();
                return View("Agregar", vista);
            }
            return RedirectToAction("Index");
        }
    }
}

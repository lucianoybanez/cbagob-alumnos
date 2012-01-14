﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using JLY.Hotel.Web.Controllers;

namespace CbaGob.Alumnos.Web.Controllers
{
    public class UsuarioController : BaseController
    {
        private IUsuarioServicio usuarioServicio;

        public UsuarioController(IUsuarioServicio usuarioServicio)
        {
            this.usuarioServicio = usuarioServicio;
        }

        public ActionResult Index()
        {
            return View("Index",usuarioServicio.GetIndex());
        }

    }
}

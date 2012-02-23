using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using NUnit.Framework;

namespace CbaGob.Alumnos.Test.Repositories
{
    [TestFixture]
    public class FacturaRepositorioTest
    {
        private IFacturaRepositorio FacturaRepositorio;

        [SetUp]
        public void Setup()
        {
            FacturaRepositorio = new FacturaRepositorio();
        }

        [Test]
        public void AgregarFacturaTest()
        {
            IFactura factura = new Factura()
                                   {
                                       Concepto = "Concepto test",
                                       IdCondicionCurso = 1,
                                       MontoTotal = 100,
                                       NroFactura = "123456",
                                       DetalleFactura = new DetalleFactura()
                                                            {
                                                                Descripcion = "Abap",
                                                                Item = "Abap item",
                                                                Monto = 100,
                                                            }
                                   };
            int result = FacturaRepositorio.AgregarFactura(factura);
            Assert.IsTrue(result!=0);
        }

    }
}

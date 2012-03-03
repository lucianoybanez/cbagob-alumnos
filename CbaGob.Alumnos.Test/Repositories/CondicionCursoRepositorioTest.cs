using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using CbaGob.Alumnos.Repositorio.Models;
using NUnit.Framework;

namespace CbaGob.Alumnos.Test.Repositories
{
    [TestFixture]
    public class CondicionCursoRepositorioTest
    {
        private ICondicionCursoRepositorio repo;

        [SetUp]
        public void Setup()
        {
            repo = new CondicionCursoRepositorio();
           

        }

        [Test]
        public void GetCondicion()
        {
            var a = repo.GetCondicion(8);

            if (a!=null)
            {
                Debug.WriteLine(a.NombeInstitucion);
                Debug.WriteLine(a.NombrePrograma);
            }

            Assert.IsTrue(a!=null);

        }

        [Test]
        public void GetCondicionCursoVariousParameter()
        {
            var a = repo.GetCondicionCursoBy(27,41, 0, 0, 0,0);
            Debug.WriteLine(a.Count);
           

            Assert.IsTrue(a.Count==1);

        }

        [Test]
        public void GetCondicionCursoVarious()
        {
            var a = repo.BuscarCondiciones("", "int", "");
            Debug.WriteLine(a.Count);


            Assert.IsTrue(a.Count>0);

        }

    }
}

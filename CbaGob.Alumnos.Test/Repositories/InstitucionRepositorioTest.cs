using System.Diagnostics;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using NUnit.Framework;

namespace CbaGob.Alumnos.Test.Repositories
{
    [TestFixture]
    public class InstitucionRepositorioTest
    {

        private IInstitucionRepositorio _institucionRepositorio;

        private IAlumnosRepositorio AlumnosRepositorio;

        [SetUp]
        public void Setup()
        {
            _institucionRepositorio = new InstitucionRepositorio();
            AlumnosRepositorio = new AlumnosRepositorio();
        }

        [Test]
        public void Test()
        {
            IInstitucion institucion = _institucionRepositorio.GetInstitucion(26);


            Assert.IsTrue(institucion != null);
        }

        [Test]
        public void testalumnos()
        {
            var a = AlumnosRepositorio.GetTodosByNombreApellido("lu", "i");
            if (a!=null)
            {
                Debug.WriteLine(a.Count);
            }
            Assert.IsTrue(a!=null);
        }
    }
}

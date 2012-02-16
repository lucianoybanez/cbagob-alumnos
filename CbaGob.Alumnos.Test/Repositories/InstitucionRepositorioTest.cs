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

        [SetUp]
        public void Setup()
        {
            _institucionRepositorio = new InstitucionRepositorio();
        }

        [Test]
        public void Test()
        {
            IInstitucion institucion = _institucionRepositorio.GetInstitucion(26);


            Assert.IsTrue(institucion != null);
        }
    }
}

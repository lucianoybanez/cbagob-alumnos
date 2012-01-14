using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using NUnit.Framework;

namespace CbaGob.Alumnos.Test.Repositories
{
    [TestFixture]
    public class UserRepositoryTest
    {
        private IUsuarioRepositorio _usuarioRepositorio;


        [SetUp]
        public void Setup()
        {
          
            _usuarioRepositorio = new UsuarioRepositorio();
        }

        [Test]
        public void GetUserByIdTest()
        {
            IUsuario usuario = _usuarioRepositorio.GetUserById(4);
            Assert.IsTrue(usuario!=null);
        }

        [Test]
        public void GetUserBynamepasas()
        {
            IUsuario usuario = _usuarioRepositorio.GetUserByNamePassword("admin", "a123456");
            Assert.IsTrue(usuario != null);
        }

    }
}

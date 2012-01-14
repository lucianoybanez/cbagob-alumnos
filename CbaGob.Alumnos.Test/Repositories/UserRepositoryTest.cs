using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using NUnit.Framework;

namespace CbaGob.Alumnos.Test.Repositories
{
    [TestFixture]
    public class UserRepositoryTest
    {
        private IUserRepository _UserRepository;


        [SetUp]
        public void Setup()
        {
          
            _UserRepository = new UserRepository();
        }

        [Test]
        public void GetUserByIdTest()
        {
            IUser user = _UserRepository.GetUserById(4);
            Assert.IsTrue(user!=null);
        }

        [Test]
        public void GetUserBynamepasas()
        {
            IUser user = _UserRepository.GetUserByNamePassword("admin", "a123456");
            Assert.IsTrue(user != null);
        }

    }
}

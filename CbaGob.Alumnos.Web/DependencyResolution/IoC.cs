using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using CbaGob.Alumnos.Servicio.Services;
using CbaGob.Alumnos.Servicio.ServicesInterface;
using StructureMap;
namespace CbaGob.Alumnos.Web {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
               ServicesView(x);
                            Repositories(x);
                        });
            return ObjectFactory.Container;
        }

        private static void Repositories(IInitializationExpression x)
        {
            x.For<IUserRepository>().Use<UserRepository>();
        }

        private static void ServicesView(IInitializationExpression x)
        {
            x.For<IHomeService>().Use<HomeService>();
            x.For<IUserService>().Use<UserService>();
        }
    }
}
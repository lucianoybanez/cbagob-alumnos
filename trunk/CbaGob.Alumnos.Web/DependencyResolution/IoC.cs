using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using CbaGob.Alumnos.Servicio.Servicios;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
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
            x.For<IUsuarioRepositorio>().Use<UsuarioRepositorio>();
        }

        private static void ServicesView(IInitializationExpression x)
        {
            x.For<IHomeServicio>().Use<HomeServicio>();
            x.For<IAutenticacionServicio>().Use<AutenticacionServicio>();
            x.For<IUsuarioServicio>().Use<UsuarioServicio>();
        }
    }
}
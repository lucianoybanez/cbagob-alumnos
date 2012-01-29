using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using CbaGob.Alumnos.Servicio.Servicios;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Web.Infrastucture;
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
            x.For<IPersonaRepositorio>().Use<PersonaRepositorio>();
        }

        private static void ServicesView(IInitializationExpression x)
        {
            x.For<IHomeServicio>().Use<HomeServicio>();
            x.For<IUsuarioServicio>().Use<UsuarioServicio>();
            x.For<IPersonaServicio>().Use<PersonaServicio>();


            // Service Web Authentications
            x.For<IHttpContextService>().Use<HttpContextService>();
            x.For<IAutenticacionServicio>().Use<AutenticacionServicio>();
        }
    }
}
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
            x.For<IInstitucionRepositorio>().Use<InstitucionRepositorio>();
            x.For<ICondicionCursoRepositorio>().Use<CondicionCursoRepositorio>();
            x.For<IModalidadRepositorio>().Use<ModalidadRepositorio>();
            x.For<INivelRepositorio>().Use<NivelRepositorio>();
            x.For<IProgramaRepositorio>().Use<ProgramaRepositorio>();
            x.For<ICursosRepositorio>().Use<CursosRepositorio>();
            x.For<IEstadoCursoRepositorio>().Use<EstadoCursoRepositorio>();
            x.For<IFacturaRepositorio>().Use<FacturaRepositorio>();
            x.For<IExamenRepositorio>().Use<ExamenRepositorio>();
            x.For<IGrupoRepositorio>().Use<GrupoRepositorio>();
            x.For<IInscripcionRepositorio>().Use<InscripcionRepositorio>();
        }

        private static void ServicesView(IInitializationExpression x)
        {
            x.For<IHomeServicio>().Use<HomeServicio>();
            x.For<IUsuarioServicio>().Use<UsuarioServicio>();
            x.For<IPersonaServicio>().Use<PersonaServicio>();
            x.For<IInstitucionServicio>().Use<InstitucionServicio>();
            x.For<ICondicionesCursoServicio>().Use<CondicionesCursoServicio>();
            x.For<IDomiciliosServicios>().Use<DomiciliosServicios>();
            x.For<IFacturaServicio>().Use<FacturaServicio>();
            x.For<IAlumnosServicios>().Use<AlumnosServicios>();
            // Service Web Authentications
            x.For<IHttpContextService>().Use<HttpContextService>();
            x.For<IAutenticacionServicio>().Use<AutenticacionServicio>();
            x.For<IExamenServicio>().Use<ExamenServicio>();
            x.For<IInscripcionServicio>().Use<InscripcionServicio>();
        }
    }
}
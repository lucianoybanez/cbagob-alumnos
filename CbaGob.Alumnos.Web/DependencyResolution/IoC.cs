using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using CbaGob.Alumnos.Servicio.Servicios;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Web.Infrastucture;
using StructureMap;

namespace CbaGob.Alumnos.Web
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
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
            x.For<ILoggedUserHelper>().Use<LoggedUserHelper>();
            x.For<IBaseRepositorio>().Use<BaseRepositorio>();
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
            x.For<IAlumnosRepositorio>().Use<AlumnosRepositorio>();
            x.For<IEstablecimientoRepositorio>().Use<EstablecimientoRepositorio>();
           
            x.For<IHorarioRepositorio>().Use<HorarioRepositorio>();
            x.For<IEquipoRepositorio>().Use<EquipoRepositorio>();
            x.For<IEstado_EquipoRepositorio>().Use<Estado_EquipoRepositorio>();
            x.For<IAreaTipoCursoRepositorio>().Use<AreaTipoCursoRepositorio>();
            x.For<ISupervisoresRepositorio>().Use<SupervisoresRepositorio>();
            x.For<IPrestamoRepositorio>().Use<PrestamoRepositorio>();
            x.For<IMovimientoRepositorio>().Use<MovimientoRepositorio>();
            x.For<ISupervicionesRepositorio>().Use<SupervicionesRepositorio>();
            x.For<ICajaChicaRepositorio>().Use<CajaChicaRepositorio>();
            x.For<IDocentesRepositorio>().Use<DocentesRepositorio>();
            x.For<ICargosRepositorio>().Use<CargosRepositorio>();
            x.For<ITipo_DocentesRepositorio>().Use<Tipo_DocentesRepositorio>();
            x.For<ITipo_DniRepositorio>().Use<Tipo_DniRepositorio>();
            x.For<ITipo_EstadoCivilRepositorio>().Use<Tipo_EstadoCivilRepositorio>();
            x.For<ITipo_SexoRepositorio>().Use<Tipo_SexoRepositorio>();
            x.For<IDomiciliosRepositorio>().Use<DomiciliosRepositorio>();
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
            x.For<IHttpContextService>().Use<HttpContextService>();
            x.For<IAutenticacionServicio>().Use<AutenticacionServicio>();
            x.For<IExamenServicio>().Use<ExamenServicio>();
            x.For<IInscripcionServicio>().Use<InscripcionServicio>();
            x.For<IAreasTipoCursoServicio>().Use<AreasTipoCursoServicio>();
            x.For<IGrupoServicio>().Use<GrupoServicio>();
            x.For<IHorarioServicio>().Use<HorarioServicio>();
            x.For<IInventarioServicio>().Use<InventarioServicio>();
            x.For<IEquipoServicio>().Use<EquipoServicio>();
            x.For<ICursosServicios>().Use<CursosServicios>();
            x.For<IPrestamoServicio>().Use<PrestamoServicio>();
            x.For<ISupervisoresServicio>().Use<SupervisoresServicio>();
            x.For<ICajaChicaServicio>().Use<CajaChicaServicio>();
            x.For<IMovimientoServicio>().Use<MovimientoServicio>();
            x.For<ISupervicionesServicio>().Use<SupervicionesServicio>();
            x.For<IDocentesServicio>().Use<DocentesServicio>();
            x.For<IPersonaJuridicaServicio>().Use<PersonaJuridicaServicio>();
            x.For<ICargosServicio>().Use<CargosServicio>();
            x.For<IEstablecimientoServicio>().Use<EstablecimientoServicio>();
            x.For<IDocentesServicio>().Use<DocentesServicio>();
        }
    }
}
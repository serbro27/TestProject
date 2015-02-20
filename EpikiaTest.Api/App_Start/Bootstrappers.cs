using Autofac;
using Autofac.Integration.WebApi;
using EpikiaTest.BusinessLogic;
using EpikiaTest.BusinessLogic.Implementation;
using EpikiaTest.DAL;
using EpikiaTest.DAL.Implementation;
using System.Reflection;
using System.Web.Http;

namespace EpikiaTest.Api
{
    public class Bootstrappers
    {
        public static void Initialize(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            
            builder.RegisterType<EpikiaTestContext>().As<IDbContext>().InstancePerRequest();
            builder.RegisterType<ActorService>().As<IActorService>().InstancePerRequest();
            builder.RegisterType<TransporterService>().As<ITransporterService>().InstancePerRequest();
            builder.RegisterType<CarrierService>().As<ICarrierService>().InstancePerRequest();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
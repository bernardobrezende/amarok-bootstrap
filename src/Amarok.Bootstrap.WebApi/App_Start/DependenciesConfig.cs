using Amarok.Bootstrap.Domain.Entities;
using Amarok.Bootstrap.Domain.Repository;
using Amarok.Bootstrap.Infrastructure.Mapping.NHibernate;
using Amarok.Bootstrap.Infrastructure.Repository;
using Autofac;
using Autofac.Integration.WebApi;
using NHibernate;
using System.Configuration;
using System.Reflection;
using System.Web.Http;

namespace Amarok.Bootstrap.WebApi
{
    public static class DependenciesConfig
    {
        public static void RegisterDependencies()
        {
            /*
             * You may setup your favorite IoC container here.
             * By default, we're using Autofac.
             */
            var builder = new ContainerBuilder();            

            #region Custom Dependencies

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterGeneric(typeof(RepositoryNH<>)).As(typeof(IRepository<>)).InstancePerApiRequest();
            builder.RegisterType<ConcreteFeatureRepository>().As<IFeatureRepository>().InstancePerApiRequest();
            builder.RegisterInstance<ISessionFactory>(new SessionFactoryBuilder().Create(ConfigurationManager.ConnectionStrings["Amarok_Db"].ConnectionString, typeof(Entity).Assembly));
            builder.Register(c => c.Resolve<ISessionFactory>().OpenSession()).As<ISession>().InstancePerApiRequest();

            #endregion

            IContainer container = builder.Build();
            // Configure Web API with the dependency resolver.
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
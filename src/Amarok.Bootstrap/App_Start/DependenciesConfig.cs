using Amarok.Bootstrap.Domain.Entities;
using Amarok.Bootstrap.Domain.Repository;
using Amarok.Bootstrap.Infrastructure.Mapping.NHibernate;
using Amarok.Bootstrap.Infrastructure.Repository;
using Autofac;
using Autofac.Integration.Mvc;
using NHibernate;
using System.Configuration;
using System.Reflection;
using System.Web.Mvc;

namespace Amarok.Bootstrap
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

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<ConcreteFeatureRepository>().As<IFeatureRepository>().InstancePerHttpRequest();
            builder.RegisterInstance<ISessionFactory>(new SessionFactoryBuilder().Create(ConfigurationManager.ConnectionStrings["Amarok_Db"].ConnectionString, typeof(Entity).Assembly));
            builder.Register(c => c.Resolve<ISessionFactory>().OpenSession()).As<ISession>().InstancePerHttpRequest();

            #endregion

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
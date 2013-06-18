using Amarok.Bootstrap.Domain.Repository;
using Amarok.Bootstrap.Infrastructure.Repository;
using Autofac;
using Autofac.Integration.Mvc;
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
            builder.Register(c => new ConcreteFeatureRepository()).As<IFeatureRepository>().InstancePerHttpRequest();

            #endregion

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
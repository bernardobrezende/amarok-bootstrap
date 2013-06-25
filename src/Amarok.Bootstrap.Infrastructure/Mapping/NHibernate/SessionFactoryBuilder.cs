using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System.Reflection;

namespace Amarok.Bootstrap.Infrastructure.Mapping.NHibernate
{
    public class SessionFactoryBuilder
    {
        public ISessionFactory Create(string connectionString, Assembly mappingAssembly)
        {
            var sessionFactory = Fluently.Configure()
                //.Database(SQLiteConfiguration.Standard.InMemory)
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString))
                .Mappings(m => m.AutoMappings.Add(
                    new AutoPersistenceModel().AddMappingsFromAssembly(mappingAssembly)
                .Where(type => type.Namespace.EndsWith("Entities"))))
                .BuildSessionFactory();

            return sessionFactory;
        }
    }
}
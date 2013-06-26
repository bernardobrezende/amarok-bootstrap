using Amarok.Bootstrap.Domain.Entities;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
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
                .Mappings(x =>
                {
                    x.AutoMappings.Add(AutoMap.Assembly(mappingAssembly)
                    .IgnoreBase<Entity>()
                    .Where(type => type.Namespace.EndsWith("Entities")));
                })
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
                .BuildSessionFactory();

            return sessionFactory;
        }
    }
}
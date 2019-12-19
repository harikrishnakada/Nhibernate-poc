using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernate.Type;

namespace Nhibernate_poc
{
    public static class NhibernateExtensions
    {
        public static ISessionFactory sessionFactory;

        public static void AddNHibernate(string connectionString)
        {
            var mapper = new ModelMapper();

            mapper.AddMappings(typeof(NhibernateExtensions).Assembly.ExportedTypes);
            HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            var configuration = new Configuration();
            configuration.DataBaseIntegration(c =>
            {
                c.Dialect<MsSql2012Dialect>();
                c.ConnectionString = connectionString;
                c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                // c.SchemaAction = SchemaAutoAction.Validate;
                c.LogFormattedSql = true;
                c.LogSqlInConsole = true;
            });

            configuration.AddMapping(domainMapping);

            var isActiveFilter = new NHibernate.Engine.FilterDefinition("isActiveFilter",
               // Use COALESCE for the filter to handle cases where NHibernate uses the filter on tables that are LEFT
               // OUTER JOINed in. In these cases, if there are no data, the column will be NULL and the entire record
               // will be excluded. To prevent this, handle NULL isActive values.
               "COALESCE(isActive, 1) = :isActive",
               new Dictionary<string, IType> { { "isActive", NHibernateUtil.Boolean } },
               false);
            configuration.AddFilterDefinition(isActiveFilter);

            //var mapping = CreateMapping();
            //configuration.AddMapping(mapping);

            sessionFactory = configuration.BuildSessionFactory();

            // services.AddSingleton(sessionFactory);
            //services.AddScoped(factory => sessionFactory.OpenSession());
            //services.AddScoped<IMapperSession, NHibernateMapperSession>();
        }
    }
}
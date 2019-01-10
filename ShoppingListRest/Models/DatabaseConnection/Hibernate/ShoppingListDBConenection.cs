using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;
using ShoppingListRest.Models.Entities;

namespace ShoppingListRest.Models.DatabaseConnection.Hibernate
{
    public class ShoppingListDBConenection : IHibernateConnection
    {
        public ShoppingListDBConenection()
        {
            CreateSessionFactory();
        }

        public ISessionFactory SessionFactory { get; private set; }
        public ISession OpenSession()
        {
            if (CurrentSessionContext.HasBind(SessionFactory))
                return SessionFactory.GetCurrentSession();

            var session = SessionFactory.OpenSession();
            CurrentSessionContext.Bind(session);
            return session;
        }

        public IStatelessSession OpenStatelessSession()
        {
            return SessionFactory.OpenStatelessSession();
        }

        private void CreateSessionFactory()
        {
            SessionFactory = Fluently
                .Configure().Database(MsSqlConfiguration.MsSql2012.ConnectionString(
                        c => c.FromConnectionStringWithKey("ShoppingListDB")
                    )
                //.ShowSql()
                )
                .CurrentSessionContext("web")
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Item>())
                .BuildSessionFactory();
        }
    }
}
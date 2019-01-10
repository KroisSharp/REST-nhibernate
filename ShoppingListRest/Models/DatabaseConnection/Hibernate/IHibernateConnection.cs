using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingListRest.Models.DatabaseConnection.Hibernate
{
    public interface  IHibernateConnection
    {
        ISession OpenSession();
        IStatelessSession OpenStatelessSession();
    }
}
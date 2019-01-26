using NHibernate.Criterion;
using ShoppingListRest.Controllers.Respository;
using ShoppingListRest.Models.DatabaseConnection.Hibernate;
using ShoppingListRest.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingListRest.Models.Respository.Hibernate
{
    public class ItemRespository : IItemRespository
    {
        private readonly IHibernateConnection _hibernateConection;

        public ItemRespository(IHibernateConnection hibernateConection)
        {
            _hibernateConection = hibernateConection;
        }

        public IList<Item> GetItemsByUID(string uid)
        {
            var session = _hibernateConection.OpenSession();
            return session.QueryOver<Item>()
                .Where(x => x.UID == uid)
                .List();
        }

        public bool UserOk(string uid)
        {
            var session = _hibernateConection.OpenSession();
            var _user = session.Query<Item>()
                .Where(x => x.UID == uid)
                .FirstOrDefault();

            if (_user == null) return false;

            return true;
        }
    }
}
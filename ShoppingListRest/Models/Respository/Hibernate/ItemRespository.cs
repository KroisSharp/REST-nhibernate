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
            User _user = null;

            var session = _hibernateConection.OpenSession();
            return session.QueryOver<Item>()
                .Where(x => x.Name == "mælk")
                .List();
        }
    }
}
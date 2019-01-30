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
            var _mylist = session.QueryOver<Item>()
                 .Where(x => x.UID == uid)
                 .List();
            return _mylist;
        }

        public Item PostItem(Item item)
        {
            var session = _hibernateConection.OpenSession();
            var transaction = session.BeginTransaction();
            session.SaveOrUpdate(item);
            transaction.Commit();
            return item;
        }

        public void DeleteItem(Item item)
        {
            var session = _hibernateConection.OpenSession();
            var transaction = session.BeginTransaction();
            //clear session da flere bliver brugt - NHibernate.NonUniqueObjectException
            session.Clear();
            session.Delete(item);
            transaction.Commit();
        }

        public Item PutItem(Item item)
        {
            var session = _hibernateConection.OpenSession();
            var transaction = session.BeginTransaction();
            //clear session da flere bliver brugt - NHibernate.NonUniqueObjectException
            session.Clear();
            session.SaveOrUpdate(item);
            transaction.Commit();
            return item;
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

        public bool DoesIDMatchUID(string uid, int id)
        {
            var session = _hibernateConection.OpenSession();
            var _result = session.Query<Item>()
                .Where(x => x.UID == uid && x.Id == id)
                .FirstOrDefault();
            
            if (_result == null) return false;

            return true;
        }


    }
}
using FluentNHibernate.Mapping;
using ShoppingListRest.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingListRest.Models.Mappings.Hibernate
{
    public class ItemMap : ClassMap<Item>
    {
        public ItemMap()
        {
            Table("Item");
            Id(x => x.Id)
                .Column("Id");
            Map(x => x.Name)
                .Column("Name");
            Map(x => x.Price)
                .Column("Price");
            Map(x => x.Category)
                .Column("Category");
            Map(x => x.UID)
                .Column("UID");
        }
    }
}
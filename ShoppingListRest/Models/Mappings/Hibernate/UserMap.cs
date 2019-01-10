using FluentNHibernate.Mapping;
using ShoppingListRest.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingListRest.Models.Mappings.Hibernate
{
    public class UserMap : ClassMap<User>
    {
        UserMap()
        {
            Table("User");
            Id(x => x.Id)
                .Column("Id");
            Map(x => x.UID)
                .Column("UID");
            Map(x => x.Email)
                .Column("Email");
        }
    }
}
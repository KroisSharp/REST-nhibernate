using FluentNHibernate.Mapping;
using ShoppingListRest.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingListRest.Models.Mappings.Hibernate
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table("Category");
            Id(x => x.Id)
                .Column("Id");
            Map(x => x.Department)
                .Column("Department");
        }
    }
}